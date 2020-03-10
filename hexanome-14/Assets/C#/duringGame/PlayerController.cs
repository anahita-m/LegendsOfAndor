using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

namespace Andor{
public class PlayerController : MonoBehaviour
{
    private PhotonView pv;
    protected Player player;
    private Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        pv = GetComponent<PhotonView>();
    }
}
}
