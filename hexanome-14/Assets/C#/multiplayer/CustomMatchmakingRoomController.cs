using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Andor{
public class CustomMatchmakingRoomController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int multiPlayerSceneIndex; //scene index for loading multiplayer scene

    [SerializeField]
    private GameObject lobbyPanel; //display for when in lobby
    [SerializeField]
    private GameObject roomPanel; //display for when in room

    [SerializeField]
    private GameObject startButton; //only for the master client. used to start the game and load the multiplayer scene

    [SerializeField]
    private Transform playersContainer; //used to display all the players in the current room
    [SerializeField]
    private GameObject playerListingPrefab; //Instantiate to display each player in the room

    [SerializeField]
    private Text roomNameDisplay; //display for the name of the room

    [HideInInspector]
    public Player localPlayer;

    private string playerPrefabName = "sphere";

    void ClearPlayerListings()
    {
        for (int i = playersContainer.childCount - 1; i >= 0; i--) //loop through all child object of the playersContainer, removing each child
        {
            Destroy(playersContainer.GetChild(i).gameObject);
        }
    }

    void ListPlayers() 
    {

        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList) //loop through each player and create a player listing
        {
            GameObject tempListing = Instantiate(playerListingPrefab, playersContainer);
            Text tempText = tempListing.transform.GetChild(0).GetComponent<Text>();
            tempText.text = player.NickName;
        }
        
    }

    // called after clicking create or joining an existing room.
    public override void OnJoinedRoom()//called when the local player joins the room
    {
        roomPanel.SetActive(true); //activate the display for being in a room
        lobbyPanel.SetActive(false); //hide the display for being in a lobby
        roomNameDisplay.text = PhotonNetwork.CurrentRoom.Name; //update room name display
        if (PhotonNetwork.IsMasterClient) //if master client then activate the start button
        {
            startButton.SetActive(true);
        }
        else
        {
            startButton.SetActive(false);
        }
        //photonPlayers = PhotonNetwork.PlayerList;
        ClearPlayerListings(); //remove all old player listings
        ListPlayers(); //relist all current player listings
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer) //called whenever a new player enter the room
    {
        ClearPlayerListings(); //remove all old player listings
        ListPlayers(); //relist all current player listings

        // Player.RefreshInstance(ref localPlayer, playerPrefabName);
    }
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)//called whenever a player leave the room
    {
        ClearPlayerListings();//remove all old player listings
        ListPlayers();//relist all current player listings
        if (PhotonNetwork.IsMasterClient)//if the local player is now the new master client then we activate the start button
        {
            startButton.SetActive(true);
        }
    }

    //loads main menu scene
    public void StartGameOnClick() //paired to the start button. will load all players into the multiplayer scene through the master client and AutomaticallySyncScene
    {
        if(PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false; //Comment out if you want player to join after the game has started
            PhotonNetwork.LoadLevel(8);   
        }
    }

    IEnumerator rejoinLobby()
    {
        yield return new WaitForSeconds(1);
        PhotonNetwork.JoinLobby();
    }

    public void BackOnClick() // paired to the back button in the room panel. will return the player to the lobby panel.
    {
        lobbyPanel.SetActive(true);
        roomPanel.SetActive(false);
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();
        StartCoroutine(rejoinLobby());
    }

    
}
}
