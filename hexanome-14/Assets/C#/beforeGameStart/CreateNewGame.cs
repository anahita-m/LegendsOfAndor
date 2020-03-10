using UnityEngine.SceneManagement;
using UnityEngine;
using Photon.Pun;

public class CreateNewGame : MonoBehaviour
{
    public void GameLobby()
    {
        SceneManager.LoadScene("GameRoom");
    }
}
