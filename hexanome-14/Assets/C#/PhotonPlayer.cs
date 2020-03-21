using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
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


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Instantiating avatar");
        PV = GetComponent<PhotonView>();
        //PV.TransferOwnership(PhotonNetwork.LocalPlayer);
        int spawnPicker = UnityEngine.Random.Range(0, GameSetupController.GS.spawnPoints.Length);


        if (PV.IsMine)
        {
            initPosition = PlayerPrefs.GetString("CharacterRank");
            initialPos = GameObject.FindWithTag(initPosition).GetComponent<BoardPosition>().getMiddle();
            string heroType = getTag(PlayerPrefs.GetString("CharacterRank"));

            // // prevents from creating multiple players of the same type upon scene change!
            // if (GameObject.FindWithTag(heroType))
            // {
            //     Destroy(GameObject.FindWithTag(heroType));
            // }

            Debug.Log("Instantiating avatar2");

            int myPlayerNumber = PhotonNetwork.LocalPlayer.ActorNumber;

            //GameSetupController.GS.spawnPoints[spawnPicker].position
            myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Avatar"), initialPos
                   , GameSetupController.GS.spawnPoints[spawnPicker].rotation, 0);
            Debug.Log("created avatar");

            Andor.Player p = myAvatar.GetComponent<Andor.Player>();
            p.setNewPos(initialPos);
            // for some reason this onnnnly works for 1 client
            p.setTag(heroType);

            //myAvatar.GetComponent<GameUnit>().setPhysicalObject(myAvatar);
            //myAvatar.GetComponent<GameUnit>().setType(FlashPointGameConstants.GAMEUNIT_TYPE_FIREMAN);

            //Hashtable props = new Hashtable
            //{
            //    {FlashPointGameConstants.PLAYER_READY_FOR_PLACEMENT, true }
            //};
            //PhotonNetwork.LocalPlayer.SetCustomProperties(props);
        }

    }

    private string getTag(string pos)
    {
        int tag = 0;
        try
        {
            tag = int.Parse(pos);
        }
        catch (InvalidCastException e)
        { Debug.Log("should never happen, photon player.cs"); }

        switch(tag)
        {
            case 7:
                return "dwarf";
            case 14:
                return "warrior";
            case 25:
                return "archer";
            case 34:
                return "wizard";
            default:
                return "";
        }
    }



    public void Initialize(int id, string name)
    {
        Id = id;
        PlayerName = name;
    }
}
