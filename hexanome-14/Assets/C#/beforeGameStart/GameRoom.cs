﻿using UnityEngine.SceneManagement;
using Photon.Pun;
using UnityEngine;

public class GameRoom : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Play_Game");
    }
}
