using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class GameRoom : MonoBehaviourPunCallbacks

{

    [SerializeField]
    private int andorBoardIndex; //1

  //  [SerializeField]
   // private GameObject roomPanel; //panel for displaying lobby.
   // [SerializeField]
   // private GameObject chooseCharacterPanel; //panel for displaying the main menu

    //choose character
    [SerializeField]
    public GameObject MaleWizardButton; //displays Loading while connecting to Photon servers.
    [SerializeField]
    public GameObject FemaleWizardButton; //button used for joining a Lobby.
    [SerializeField]
    public GameObject MaleDwarfButton; //panel for displaying lobby.
    [SerializeField]
    public GameObject FemaleDwarfButton; //panel for displaying the main menu
    [SerializeField]
    public GameObject MaleArcherButton; //displays Loading while connecting to Photon servers.
    [SerializeField]
    public GameObject FemaleArcherButton; //button used for joining a Lobby.
    [SerializeField]
    public GameObject MaleWarriorButton; //panel for displaying lobby.
    [SerializeField]
    public GameObject FemaleWarriorButton; //panel for displaying the main menu

    [SerializeField]
    public GameObject startButton; //panel for displaying the main menu
    public int i = 4;
    public string[] initialCharTurn = new string[4];

    //public override void OnConnectedToMaster() //Callback function for when the first connection is established successfully.
    public void OnEnter()
    {
       // roomPanel.SetActive(false); //activate the display for being in a room
       // chooseCharacterPanel.SetActive(true);
        PhotonNetwork.AutomaticallySyncScene = true; //Makes it so whatever scene the master client has loaded is the scene all other clients will load
        if (PhotonNetwork.IsMasterClient) //if master client then activate the start button
        {
            startButton.SetActive(true);
        }
        else
        {
            startButton.SetActive(false);
        }
    }


   public void StartGame()
    {
        PhotonNetwork.LoadLevel(2);
    }

    public void MaleWizardOnClick()
    {
        PlayerPrefs.HasKey("Player-Male-Wizard");
        MaleWizardButton.SetActive(false);
        FemaleWizardButton.SetActive(false);
        i--;
    }

    public void FemaleWizardOnClick()
    {
        PlayerPrefs.HasKey("Player-Female-Wizard");
        FemaleWizardButton.SetActive(false);
        MaleWizardButton.SetActive(false);
        i--;
    }

    public void MaleDwarfOnClick()
    {
        PlayerPrefs.HasKey("Player-Male-Dwarf");
        MaleDwarfButton.SetActive(false);
        FemaleDwarfButton.SetActive(false);
        i--;
    }

    public void FemaleDwarfOnClick()
    {
        PlayerPrefs.HasKey("Player-Female-Dwarf");
        FemaleDwarfButton.SetActive(false);
        MaleDwarfButton.SetActive(false);
        i--;
    }

    public void MaleArcherOnClick()
    {
        PlayerPrefs.HasKey("Player-Male-Archer");
        MaleArcherButton.SetActive(false);
        FemaleArcherButton.SetActive(false);
        i--;
    }

    public void FemaleArcherOnClick()
    {
        PlayerPrefs.HasKey("Player-Female-Archer");
        FemaleArcherButton.SetActive(false);
        MaleArcherButton.SetActive(false);
        i--;
    }

    public void MaleWarriorOnClick()
    {
        PlayerPrefs.HasKey("Player-Male-Warrior");
        MaleWarriorButton.SetActive(false);
        FemaleWarriorButton.SetActive(false);
        i--;
    }

    public void FemaleWarriorOnClick()
    {
        PlayerPrefs.HasKey("Player-Female-Warrior");
        FemaleWarriorButton.SetActive(false);
        MaleWarriorButton.SetActive(false);
        i--;
    }

    //public void checkAllCharacters()
    //{
    //    if(i == 0)
    //    {
    //        if (PhotonNetwork.IsMasterClient)//if the local player is now the new master client then we activate the start button
    //        {
    //            startButton.SetActive(true);
    //        }
    //    }
    //}


}