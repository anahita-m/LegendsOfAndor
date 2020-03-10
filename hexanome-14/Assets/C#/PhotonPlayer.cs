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

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Instantiating avatar");
        PV = GetComponent<PhotonView>();
        //PV.TransferOwnership(PhotonNetwork.LocalPlayer);
        int spawnPicker = Random.Range(0, GameSetupController.GS.spawnPoints.Length);
        if (PV.IsMine)
        {
            Debug.Log("Instantiating avatar2");

            int myPlayerNumber = PhotonNetwork.LocalPlayer.ActorNumber;
            myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Avatar"),
                   GameSetupController.GS.spawnPoints[spawnPicker].position, GameSetupController.GS.spawnPoints[spawnPicker].rotation, 0);
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
