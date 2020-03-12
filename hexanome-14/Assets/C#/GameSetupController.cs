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
        playerObject.AddComponent<Hero>();
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

    // Start is called before the first frame update
    //Instantiates player prefab.
    void Start()
    {
        IsSpawningPrefabs = true;
        if (PhotonNetwork.IsConnected)
        {
            GameObject entry = CreatePlayer();

            string playerName = PhotonNetwork.LocalPlayer.NickName;
            int id = PhotonNetwork.LocalPlayer.ActorNumber;
            entry.GetComponent<PhotonPlayer>().Initialize(id, playerName);
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