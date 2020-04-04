﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Photon.Pun;
using UnityEngine;

public class NetworkHandler : MonoBehaviour
{
    [PunRPC]
    public void HOSTaddPlayer(Andor.Player p) // Only host should get this called
    {
        Game.getGame().addPlayer(p);
        Game.updateClients();
        Debug.Log(Game.myPlayer.getNetworkID() + " ~ Added Player");
    }

    [PunRPC]
    public void updatePlayerList(List<Andor.Player> players)
    {
        foreach (Andor.Player p in players)
        {
            if (!Game.getGame().hasPlayer(p))
            {
                Game.getGame().addPlayer(p);
                Debug.Log(Game.myPlayer.getNetworkID() + " ~ Added Player: " + p.getNetworkID());
            }
        }
    }

    //Clients get this method called to update a specific player
    [PunRPC]
    public void updatePlayer(Andor.Player p)
    {
        Game.getGame().updatePlayer(p);
        Debug.Log(Game.myPlayer.getNetworkID() + " ~ Updated Player");
    }

    [PunRPC]
    public void updateLegend(byte legend)
    {
        Game.getGame().legend = legend;
    }

    [PunRPC]
    public void sendAction(Action a)
    {
        Game.getGame().processAction(a);
    }


    public static byte[] SerializeThis(object obj)
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (var ms = new MemoryStream())
        {
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
    }

    // Convert a byte array to an Object
    public static object Deserialize(byte[] arrBytes)
    {
        using (var memStream = new MemoryStream())
        {
            var binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            var obj = binForm.Deserialize(memStream);
            return obj;
        }
    }

}