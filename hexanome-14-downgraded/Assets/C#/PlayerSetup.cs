using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    //Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
    }

    // Update is called once per frame
    private void CreatePlayer()
    {
        Debug.Log("Creating Player");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), Vector3.zero, Quaternion.identity);
       // GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer);

    }
}
