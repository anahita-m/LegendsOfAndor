using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{
    private PhotonView PV;
    public GameObject myAvatar;
    public int Id;
    public string PlayerName;
    public string initPosition;
    public Vector3 initialPos;
    public GameObject skral;
    public Dictionary<string, string> playerPositions = new Dictionary<string, string>();



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Instantiating avatar");
        PV = GetComponent<PhotonView>();
        //PV.TransferOwnership(PhotonNetwork.LocalPlayer);
        int spawnPicker = Random.Range(0, GameSetupController.GS.spawnPoints.Length);


        if (PV.IsMine)
        {
            //this is where
            initPosition = PlayerPrefs.GetString("CharacterRank");
            string character = PlayerPrefs.GetString("MyCharacter");
            playerPositions.Add(character, initPosition);
            Debug.Log(playerPositions.Count);
            Debug.Log(PhotonNetwork.PlayerList.Length);

            if (playerPositions.Count == PhotonNetwork.PlayerList.Length)
            {
                BoardContents.initAndGetPlayers(playerPositions);
                Debug.Log("Init positions");

            }

            initialPos = GameObject.FindWithTag(initPosition).GetComponent<BoardPosition>().getMiddle();

            Debug.Log("Instantiating avatar2");

            int myPlayerNumber = PhotonNetwork.LocalPlayer.ActorNumber;

            //GameSetupController.GS.spawnPoints[spawnPicker].position
            myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Avatar"), initialPos
                   , GameSetupController.GS.spawnPoints[spawnPicker].rotation, 0);
            
            Debug.Log("created avatar");

            //myAvatar.GetComponent<GameUnit>().setPhysicalObject(myAvatar);
            //myAvatar.GetComponent<GameUnit>().setType(FlashPointGameConstants.GAMEUNIT_TYPE_FIREMAN);

            //Hashtable props = new Hashtable
            //{
            //    {FlashPointGameConstants.PLAYER_READY_FOR_PLACEMENT, true }
            //};
            //PhotonNetwork.LocalPlayer.SetCustomProperties(props);
        }

    }

    public void Initialize(int id, string name)
    {
        Id = id;
        PlayerName = name;
    }
}
