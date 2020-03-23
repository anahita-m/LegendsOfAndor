//using Photon.Pun;
//using System.IO;
//using UnityEngine;

//public class GameSetupController : MonoBehaviour
//{

//    public static GameSetupController GS;
//    public Transform[] spawnPoints;

//    private void OnEnable()
//    {
//        if(GameSetupController.GS == null)
//        {
//            GameSetupController.GS = this;
//        }
//    }
//}



using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using System;
using ExitGames.Client.Photon;
using Andor;
using UnityEngine.UI;

public class GameSetupController : MonoBehaviourPunCallbacks
{
    //Vector3 intPos = GameObject.FindWithTag().GetComponent<BoardPosition>().getMiddle();

    public static GameSetupController GS;
    //Allows to stop Update function once all Players are spawned.
    public bool IsSpawningPrefabs;
    public Transform[] spawnPoints;

    public string mySelectedCharacter;
    //Initial Spawnpoints prior to start position selection.
    //public Vector3[] initialPositions;
    public String initPosition;
    public Vector3 initialPos;
    public Button startButton;
    public int c = 0;
    public Dictionary<string, string> skralPositions = new Dictionary<string, string>();
    public Dictionary<string, string> gorPositions = new Dictionary<string, string>();
    public Dictionary<string, string> trollPositions = new Dictionary<string, string>();
    public Dictionary<string, string> wardakPositions = new Dictionary<string, string>();

    public Dictionary<string, string> monsterPositions = new Dictionary<string, string>();



    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        if (GameSetupController.GS == null)
        {
            GameSetupController.GS = this;
            //initPosition = PlayerPrefs.GetString("CharacterRank");
 //           initialPos = GameObject.FindWithTag("14").GetComponent<BoardPosition>().getMiddle();
            //initPos = new Vector3[6];
            //Vector3 topPosition = new Vector3(-8.9f, -1.28f, 0);
            //for (int i = 0; i < initialPositions.Length; i++)
            //{
            //    initialPositions[i] = topPosition;
            //    topPosition = new Vector3(topPosition.x, topPosition.y - 0.92f, 0);
            //}


        }
        else
        {
            if (GameSetupController.GS != this)
            {
                Destroy(GameSetupController.GS);
                GameSetupController.GS = this;
            }
        }
    }


    private GameObject CreatePlayer()
    { 
        Debug.Log("Creating Player");
        GameObject playerObject = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), Vector3.zero, Quaternion.identity);
        //GameObject.FindWithTag("14").GetComponent<BoardPosition>().getMiddle(), Quaternion.identity, 0);//
        Debug.Log("Reached Here");
        playerObject.AddComponent<Andor.Player>();
        //playerObject.AddComponent<Andor.Player>().setPlayerPos(PlayerPrefs.GetString("CharacterRank"));
        playerObject.AddComponent<Hero>();

        int spawnPicker = UnityEngine.Random.Range(0, GameSetupController.GS.spawnPoints.Length);

        if (PlayerPrefs.GetString("MyCharacter") == "archer")
        {
            Vector3 archPos = new Vector3(-6.13f, 29.90f, 0f);
            GameObject timetrackerobj = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "archerTimeTracker"), archPos, GameSetupController.GS.spawnPoints[spawnPicker].rotation);
        }
        if (PlayerPrefs.GetString("MyCharacter") == "wizard")
        {
            Vector3 wizPos = new Vector3(-8.13f, 29.90f, 0f);
            GameObject timetrackerobj = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "archerTimeTracker"), wizPos, GameSetupController.GS.spawnPoints[spawnPicker].rotation);
        }
        if (PlayerPrefs.GetString("MyCharacter") == "warrior")
        {
            Vector3 warPos = new Vector3(-10.13f, 29.90f, 0f);
            GameObject timetrackerobj = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "archerTimeTracker"), warPos, GameSetupController.GS.spawnPoints[spawnPicker].rotation);
        }
        if (PlayerPrefs.GetString("MyCharacter") == "dwarf")
        {
            Vector3 dwarfPos = new Vector3(-12.13f, 29.90f, 0f);
            GameObject timetrackerobj = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "archerTimeTracker"), dwarfPos, GameSetupController.GS.spawnPoints[spawnPicker].rotation);
        }


        Debug.Log("Reached Here 3");
        if (PlayerPrefs.HasKey("MyCharacter"))
        {
            mySelectedCharacter = PlayerPrefs.GetString("MyCharacter");
            Debug.Log("Created character: " + PlayerPrefs.GetString("MyCharacter"));
        }
        playerObject.tag = mySelectedCharacter;

        Andor.Player player = playerObject.GetComponent<Andor.Player>();
        player.setTag(mySelectedCharacter);
        return playerObject;
    }


    private void createSkral()
    {
        int spawnPicker = UnityEngine.Random.Range(0, GameSetupController.GS.spawnPoints.Length);

        GameObject skralObject = PhotonNetwork.InstantiateSceneObject(Path.Combine("PhotonPrefabs", "Skral"), GameObject.FindWithTag("9").GetComponent<BoardPosition>().getMiddle(), GameSetupController.GS.spawnPoints[spawnPicker].rotation, 0);
        skralObject.AddComponent<Monster>();
        skralObject.GetComponent<Monster>().position = "9";
        // skralObject.SetActive(true);
        skralObject.tag = "skral-1";
        DontDestroyOnLoad(skralObject);
        skralPositions.Add(skralObject.tag, skralObject.GetComponent<Monster>().position);
        monsterPositions.Add(skralObject.tag, skralObject.GetComponent<Monster>().position);

    }

    private void createGors()
    {
        int i = 1;
        foreach (string gorTile in gorLocations())
        {
            int spawnPicker = UnityEngine.Random.Range(0, GameSetupController.GS.spawnPoints.Length);

            GameObject gorObject = PhotonNetwork.InstantiateSceneObject(Path.Combine("PhotonPrefabs", "Gor"), GameObject.FindWithTag(gorTile).GetComponent<BoardPosition>().getMiddle(), GameSetupController.GS.spawnPoints[spawnPicker].rotation, 0);
            gorObject.AddComponent<Monster>();
            gorObject.GetComponent<Monster>().position = gorTile;
            Debug.Log(gorObject.GetComponent<Monster>().position);

            // skralObject.SetActive(true);
            //
            gorObject.tag = "gor" + "-" + i;
            gorPositions.Add(gorObject.tag, gorObject.GetComponent<Monster>().position);
            monsterPositions.Add(gorObject.tag, gorObject.GetComponent<Monster>().position);

            i++;
            DontDestroyOnLoad(gorObject);

        }
    }

    private void createFarmers()
    {
        int i = 1;
        foreach (string farmerTile in farmerLocations())
        {
            int spawnPicker = UnityEngine.Random.Range(0, GameSetupController.GS.spawnPoints.Length);

            GameObject farmerObject = PhotonNetwork.InstantiateSceneObject(Path.Combine("PhotonPrefabs", "Farmer"), GameObject.FindWithTag(farmerTile).GetComponent<BoardPosition>().getMiddle(), GameSetupController.GS.spawnPoints[spawnPicker].rotation, 0);
           //farmerObject.AddComponent<Monster>();
            // skralObject.SetActive(true);
            farmerObject.tag = "farmer" + "-" + i;
            i++;
            DontDestroyOnLoad(farmerObject);
        }
    }

    private void createWells()
    {
        int i = 1;
        foreach (string wellTile in wellLocations())
        {
            int spawnPicker = UnityEngine.Random.Range(0, GameSetupController.GS.spawnPoints.Length);

            GameObject wellObject = PhotonNetwork.InstantiateSceneObject(Path.Combine("PhotonPrefabs", "Well"), GameObject.FindWithTag(wellTile).GetComponent<BoardPosition>().getMiddle(), GameSetupController.GS.spawnPoints[spawnPicker].rotation, 0);
            //farmerObject.AddComponent<Monster>();
            // skralObject.SetActive(true);
            wellObject.tag = "well" + "-" + i;
            i++;
            DontDestroyOnLoad(wellObject);
        }
    }

    private void createMerchants()
    {
        int i = 1;
        foreach (string merchantTile in merchantLocations())
        {
            int spawnPicker = UnityEngine.Random.Range(0, GameSetupController.GS.spawnPoints.Length);

            GameObject merchantObject = PhotonNetwork.InstantiateSceneObject(Path.Combine("PhotonPrefabs", "Merchant"), GameObject.FindWithTag(merchantTile).GetComponent<BoardPosition>().getMiddle(), GameSetupController.GS.spawnPoints[spawnPicker].rotation, 0);
            //farmerObject.AddComponent<Monster>();
            // skralObject.SetActive(true);
            merchantObject.tag = "merchant" + "-" + i;
            i++;
            DontDestroyOnLoad(merchantObject);
        }
    }


    private string[] wellLocations()
    {
        return new string[]{
            "5",
            "35",
            "45",
            "55"
        };
    }

    private string[] gorLocations()
    {
        return new string[]{
            "8",
            "20",
            "21",
            "26",
            "48"
        };
    }

    private string[] farmerLocations()
    {
        return new string[]{
            "24",
            "36"
        };
    }

    private string[] merchantLocations()
    {
        return new string[]{
            "18",
            "57",
            "71"
        };
    }

    public bool StartGameOnClick()
    {
        Debug.Log("returning true");
        return true;
    }


    // Start is called before the first frame update
    //Instantiates player prefab.
    void Start()
    {
        IsSpawningPrefabs = true;
        if (PhotonNetwork.IsConnected && StartGameOnClick())
            Debug.Log("checked start");
        {
            GameObject entry = CreatePlayer();
            string playerName = PhotonNetwork.LocalPlayer.NickName;
            int id = PhotonNetwork.LocalPlayer.ActorNumber;
            entry.GetComponent<PhotonPlayer>().Initialize(id, playerName);

            BoardContents.initAndGetMonster(monsterPositions);
            Monster.monsterPositions = monsterPositions;


            createSkral();
            BoardContents.initAndGetSkral(skralPositions);
            Monster.skralMonsterLoc = skralPositions;

            createGors();
            BoardContents.initAndGetGor(gorPositions);
            Monster.gorMonsterLoc = gorPositions;


            createFarmers();
            createWells();
            createMerchants();
        }
    }

    //private GameObject CreatePlayer()
    //{
    //    Debug.Log("Creating Player");
    //    return PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), Vector3.zero, Quaternion.identity);

    //}

    ////Checks if all players were spawned.
    //private bool CheckPlayersReadyToBePlaced()
    //{
    //    if (!PhotonNetwork.IsMasterClient)
    //    {
    //        return false;
    //    }

    //    //foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerList)
    //    //{
    //    //    object isPlayerReady;
    //    //    if (p.CustomProperties.TryGetValue(FlashPointGameConstants.PLAYER_READY_FOR_PLACEMENT, out isPlayerReady))
    //    //    {
    //    //        if (!(bool)isPlayerReady)
    //    //        {
    //    //            Debug.Log("Player " + p.NickName + " is not ready to be placed.");
    //    //            return false;
    //    //        }

    //    //    }
    //    //    else
    //    //    {

    //    //        return false;
    //    //    }

    //    //}
    //    return true;
    //}

    //void Update()
    //{
    //    if (IsSpawningPrefabs)
    //    {
    //        if (CheckPlayersReadyToBePlaced())
    //        {
    //            IsSpawningPrefabs = false;

    //            GameManager.GM.OnAllPrefabsSpawned();

    //        }

    //    }

    //}


}
