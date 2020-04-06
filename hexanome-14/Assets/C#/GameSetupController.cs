﻿//using Photon.Pun;
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
        //Debug.Log("CREATING A PLAYERRRRRR!!!!!");

        GameObject playerObject = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), Vector3.zero, Quaternion.identity);
        
        //GameObject.FindWithTag("14").GetComponent<BoardPosition>().getMiddle(), Quaternion.identity, 0);//
        //Debug.Log("Reached Here");
        Andor.Player player = playerObject.AddComponent<Andor.Player>();
        Hero hero = playerObject.AddComponent<Hero>();
        //playerObject.AddComponent<Andor.Player>().setPlayerPos(PlayerPrefs.GetString("CharacterRank"));

        //string heroPos = "";
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


        //Debug.Log("Reached Here 3");
        if (PlayerPrefs.HasKey("MyCharacter"))
        {
            mySelectedCharacter = PlayerPrefs.GetString("MyCharacter");
            //Debug.Log("Created character: " + PlayerPrefs.GetString("MyCharacter"));
        }
        playerObject.tag = mySelectedCharacter;

        player.setTag(mySelectedCharacter);
        //Hero hero = playerObject.GetComponent<Hero>();
        player.setHero(hero);
        //hero.init(playerTag, position);
        //hero.setGold(UnityEngine.Random.Range(0, 10));
        hero.position = player.position;
        //Debug.Log("Set up player pos: " + player.position);
        //player.updateCoin(mySelectedCharacter, hero.getGold());
        //Hero hero = Hero(player.getPlayerTag(), );
        //Debug.Log("Player tag " + player.getPlayerTag());
        return playerObject;
    }


    private void createSkral()
    {
        int spawnPicker = UnityEngine.Random.Range(0, GameSetupController.GS.spawnPoints.Length);

        GameObject skralObject = PhotonNetwork.InstantiateSceneObject(Path.Combine("PhotonPrefabs", "Skral"), GameObject.FindWithTag("9").GetComponent<BoardPosition>().getMiddle(), GameSetupController.GS.spawnPoints[spawnPicker].rotation, 0);
        skralObject.AddComponent<Monster>();
        // skralObject.SetActive(true);
        skralObject.tag = "skral";
        DontDestroyOnLoad(skralObject);
    }

    private void createGors()
    {
        foreach (string gorTile in gorLocations())
        {
            int spawnPicker = UnityEngine.Random.Range(0, GameSetupController.GS.spawnPoints.Length);

            GameObject gorObject = PhotonNetwork.InstantiateSceneObject(Path.Combine("PhotonPrefabs", "Gor"), GameObject.FindWithTag(gorTile).GetComponent<BoardPosition>().getMiddle(), GameSetupController.GS.spawnPoints[spawnPicker].rotation, 0);
            gorObject.AddComponent<Monster>();
            // skralObject.SetActive(true);
            gorObject.tag = "gor";
            DontDestroyOnLoad(gorObject);

        }
    }

    private void createFarmers()
    {
        foreach (string farmerTile in farmerLocations())
        {
            int spawnPicker = UnityEngine.Random.Range(0, GameSetupController.GS.spawnPoints.Length);

            GameObject farmerObject = PhotonNetwork.InstantiateSceneObject(Path.Combine("PhotonPrefabs", "Farmer"), GameObject.FindWithTag(farmerTile).GetComponent<BoardPosition>().getMiddle(), GameSetupController.GS.spawnPoints[spawnPicker].rotation, 0);
           //farmerObject.AddComponent<Monster>();
            // skralObject.SetActive(true);
            farmerObject.tag = "farmer";
            DontDestroyOnLoad(farmerObject);
        }
    }

    private void createWells()
    {
        foreach (string wellTile in wellLocations())
        {
            int spawnPicker = UnityEngine.Random.Range(0, GameSetupController.GS.spawnPoints.Length);

            GameObject wellObject = PhotonNetwork.InstantiateSceneObject(Path.Combine("PhotonPrefabs", "Well"), GameObject.FindWithTag(wellTile).GetComponent<BoardPosition>().getMiddle(), GameSetupController.GS.spawnPoints[spawnPicker].rotation, 0);
            //farmerObject.AddComponent<Monster>();
            // skralObject.SetActive(true);
            wellObject.tag = "well";
            DontDestroyOnLoad(wellObject);
        }
    }

    private void createMerchants()
    {
        
        foreach (string merchantTile in merchantLocations())
        {
            int spawnPicker = UnityEngine.Random.Range(0, GameSetupController.GS.spawnPoints.Length);

            GameObject merchantObject = PhotonNetwork.InstantiateSceneObject(Path.Combine("PhotonPrefabs", "Merchant"), GameObject.FindWithTag(merchantTile).GetComponent<BoardPosition>().getMiddle(), GameSetupController.GS.spawnPoints[spawnPicker].rotation, 0);
            //merchantObject.AddComponent<Inventory>();
            //farmerObject.AddComponent<Monster>();
            // skralObject.SetActive(true);
            merchantObject.tag = "merchant";
            merchantObject.AddComponent<Merchant>();
            
            //Merchant merchant = merchantObject.GetComponent(typeof(Merchant)) as Merchant;
            //merchant.setPosition(merchantTile);
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
            createSkral();
            createGors();
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
