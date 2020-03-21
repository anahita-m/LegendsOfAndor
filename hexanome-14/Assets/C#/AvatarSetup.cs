using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class AvatarSetup : MonoBehaviour
{

    private PhotonView PV;
    public GameObject myCharacter;
    public int characterValue;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            // if (GameObject.FindWithTag(getTheTag(PlayerInfo.PI.mySelectedCharacter)))
            //     Destroy(GameObject.FindWithTag((getTheTag(PlayerInfo.PI.mySelectedCharacter))));
            PV.RPC("RPC_AddCharacter", RpcTarget.AllBuffered, PlayerInfo.PI.mySelectedCharacter);
        }
    }

    // Update is called once per frame
    [PunRPC]
    void RPC_AddCharacter(int whichCharacter)
    {
        characterValue = whichCharacter;
        myCharacter = Instantiate(PlayerInfo.PI.allcharacters[whichCharacter], transform.position, transform.rotation, transform);
        DontDestroyOnLoad(gameObject);
        // gameObject.tag = getTheTag(whichCharacter);
    }

    public string getTheTag(int whichCharacter)
    {
        string tag = "";
        if (whichCharacter == 0 || whichCharacter == 1)
        {
            tag =  "wizard";
        }
        if (whichCharacter == 2 || whichCharacter == 3)
        {
            tag = "archer";
        }
        if (whichCharacter == 4 || whichCharacter == 5)
        {
            tag = "dwarf";
        }
        if (whichCharacter == 6 || whichCharacter == 7)
        {
            tag = "warrior";
        }
        return tag;
    }

}
