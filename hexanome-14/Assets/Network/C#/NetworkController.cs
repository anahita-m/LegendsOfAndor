﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkController : MonoBehaviourPunCallbacks
{
    /******************************************************
    * Refer to the Photon documentation and scripting API for official definitions and descriptions
    * 
    * Documentation: https://doc.photonengine.com/en-us/pun/current/getting-started/pun-intro
    * Scripting API: https://doc-api.photonengine.com/en/pun/v2/index.html
    * 
    * If your Unity editor and standalone builds do not connect with each other but the multiple standalones
    * do then try manually setting the FixedRegion in the PhotonServerSettings during the development of your project.
    * https://doc.photonengine.com/en-us/realtime/current/connection-and-authentication/regions
    *
    * ******************************************************/

    [SerializeField]
    private int gameVersion;

    public static int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        PhotonNetwork.GameVersion = gameVersion.ToString();
        Debug.Log("Connecting...");

        PhotonNetwork.ConnectUsingSettings(); //Connects to Photon master servers
        Debug.Log("Connected!");
        //Other ways to make a connection can be found here: https://doc-api.photonengine.com/en/pun/v2/class_photon_1_1_pun_1_1_photon_network.html
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("We are now connected to the " + PhotonNetwork.CloudRegion + " server!");
        PhotonNetwork.NickName = storeUsername.USERNAME;
        Debug.Log("Connected as " + storeUsername.USERNAME);


        SceneManager.LoadScene("Main_Menu");

        Debug.Log("Joining the lobby...");


        if (PhotonNetwork.JoinLobby())
        {
            Debug.Log("Joined the lobby!");

        }
        else
        {
            Debug.Log("Failed to join the lobby");

        }

    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
    }
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("Created room!");
        Debug.Log("Joining Room...");

    }

    public override void OnCreateRoomFailed(short returnCode, string message) //create room will fail if room already exists
    {
        Debug.Log("Tried to create a new room but failed, there must already be a room with the same name");
    }
    public override void OnJoinedRoom()
    {
        //base.OnJoinedRoom();

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("GameRoom");
        }

        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);

    }
}