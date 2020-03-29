using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPun
{
    public static string [] playerTagList = new string [PhotonNetwork.CountOfPlayers];
    public static int playerCount = 0;

    //public static int NumberOfPlayers;
    //ArrayList playersListCache;
    //public int Turn = 1;

    //public void OnAllPrefabsSpawned()
    //{
    //    //TODO Cache the playerList.
    //    object[] data = new object[PhotonNetwork.PlayerList.Length];
    //    int i = 0;

    //    foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerList)
    //    {
    //        Debug.Log("OnAllPrefabsSpawned sees " + p.NickName + " with ActorNumber " + p.ActorNumber);
    //        playersListNameCache.Insert(p.ActorNumber - 1, p.NickName);
    //        data[i] = playersListNameCache[i];
    //        i++;
    //    }
    //}

    //public static Photon.Realtime.RaiseEventOptions sendToAllOptions = new Photon.Realtime.RaiseEventOptions()
    //{
    //    CachingOption = Photon.Realtime.EventCaching.DoNotCache,
    //    Receivers = Photon.Realtime.ReceiverGroup.All
    //};

    public static void addPlayer(string playerTag)
    {
        playerTagList[playerCount] = playerTag;
        playerCount++;
    }

    //public static void IncrementTurn()
    //{
    //   // PhotonNetwork.RaiseEvent((byte)PhotonEventCodes.IncrementTurn, null, sendToAllOptions, SendOptions.SendReliable);
    //}

    //public void DisplayPlayerTurn()
    //{

    //    string playerName = (string)playersListCache[Turn - 1];
    //   // GameUI.instance.UpdatePlayerTurnName(playerName);
    //}



    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    //void OnClickMovePlayer()
    //{

    //}

    //void OnClickPass()
    //{

    //}

    //void OnClickEndDay()
    //{
        
    //}

    //void OnClick()
    //{

    //}

    //void OnClickBattle()
    //{

    //}
}
