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


public class GameSetupController : MonoBehaviourPunCallbacks
{

    public static GameSetupController GS;
    //Allows to stop Update function once all Players are spawned.
    public bool IsSpawningPrefabs;
    public Transform[] spawnPoints;

    //Initial Spawnpoints prior to start position selection.
    public Vector3[] initialPositions;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        if (GameSetupController.GS == null)
        {
            GameSetupController.GS = this;
            initialPositions = new Vector3[6];
            Vector3 topPosition = new Vector3(-8.9f, -1.28f, 0);
            for (int i = 0; i < initialPositions.Length; i++)
            {
                initialPositions[i] = topPosition;
                topPosition = new Vector3(topPosition.x, topPosition.y - 0.92f, 0);
            }


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

    private GameObject CreatePlayer()
    {
        Debug.Log("Creating Player");
        return PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), Vector3.zero, Quaternion.identity);

    }

    //Checks if all players were spawned.
    private bool CheckPlayersReadyToBePlaced()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return false;
        }

        //foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerList)
        //{
        //    object isPlayerReady;
        //    if (p.CustomProperties.TryGetValue(FlashPointGameConstants.PLAYER_READY_FOR_PLACEMENT, out isPlayerReady))
        //    {
        //        if (!(bool)isPlayerReady)
        //        {
        //            Debug.Log("Player " + p.NickName + " is not ready to be placed.");
        //            return false;
        //        }

        //    }
        //    else
        //    {

        //        return false;
        //    }

        //}
        return true;
    }

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