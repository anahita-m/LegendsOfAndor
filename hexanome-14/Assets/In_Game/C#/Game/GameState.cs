﻿using System.Collections;
using System;
using System.Collections.Generic;
using Andor;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;


//add code to enforce how many monsters can enter the castle 

[JsonObject(MemberSerialization.Fields)]
public class GameState
{
    private DateTime dateSaved;

	private Dictionary<string, Player> players;
    private List<Monster> monsters;
    //private Dictionary<String, Monster> monsters2;
    private Dictionary<Skral, int> skrals;
    private Dictionary<Gor, int> gors;

    public string difficulty = "-1";
    public Dictionary<string, int> playerLocations;
    public static int monstersInCastle;
    public static int maxMonstersToLose;

    public TurnManager turnManager;

    public GameState()
	{
		players = new Dictionary<string, Player>();
        monsters = new List<Monster>();
        //monsters2 = new Dictionary<string, Monster>();
        playerLocations = new Dictionary<string, int>();

    }

    public void addPlayer(Player p)
	{
        if (!players.ContainsKey(p.getNetworkID()))
        {
            players.Add(p.getNetworkID(), p);
            Debug.Log("Added player " + p);

        }
        else
        {
            Debug.Log("I already have myself/this player");
        }
        displayPlayers();

        if (!Game.started)
        {
            if(RoomLobbyController.preLoadedGameState == null)
            {
                RoomLobbyController.instance.playerListUpdate(Game.gameState.getPlayers());
            }
            else
            {
                RoomLobbyController.instance.playerListUpdateLOADED(Game.gameState.getPlayers());
            }
        }

    }
    public void updatePlayer(Player p)
    {
        if (players.ContainsKey(p.getNetworkID()))
        {   
            players[p.getNetworkID()] = p;
            Debug.Log("Player is updated!");
        }
        else
        {
            Debug.Log("Player is not registered!");
        }

        if (!Game.started)
        {
            if (RoomLobbyController.preLoadedGameState == null)
            {
                RoomLobbyController.instance.playerListUpdate(Game.gameState.getPlayers());
                int numPlayers = Game.gameState.getPlayers().Count;
                if (numPlayers == 2)
                {
                    maxMonstersToLose = 1;
                }
                else if (numPlayers == 3)
                {
                    maxMonstersToLose = 1;
                }
                else if (numPlayers == 4)
                {
                    maxMonstersToLose = 3;
                }
            }
            else
            {
                RoomLobbyController.instance.playerListUpdateLOADED(Game.gameState.getPlayers());
            }
        }
    }
    public void removeAllPlayers()
    {
        players = new Dictionary<string, Player>();
        playerLocations = new Dictionary<string, int>();
    }

    public List<Monster> getMonsters()
    {
        return monsters;
    }
    public void addMonster(Monster m)
    {
        monsters.Add(m);
    }

    ////////////////////////////////////////////////////////////////////////////
    public Dictionary<Skral, int> getSkrals()
    {
        return skrals;
    }
    public void addSkral(Skral s)
    {
        skrals.Add(s,s.getLocation());
    }
    //////////////////////////////////gors//////////////////////////////////
    public Dictionary<Gor,int> getGors()
    {
        return gors;
    }
    public void addGor(Gor g)
    {
        gors.Add(g, g.getLocation());
    }

    public void processAction(Action a)
    {
        if (a.isLegal(this)){
            a.execute(this);
        }
        
    }

    public bool playerCharacterExists(string tag)
    {
        foreach(Player p in players.Values.ToList())
        {
            if (p.getHeroType().Equals(tag))
            {
                return true;
            }
        }
        return false;
    }

    public void displayPlayers()
    {
        Debug.Log("Printing Players! Size: " + players.Count);
        Debug.Log("=================================");
        foreach (Player p in players.Values.ToList())
        {
            Debug.Log(p);
        }
        Debug.Log("=================================\n");

    }
    public List<Player> getPlayers()
    {
        return players.Values.ToList();
    }
    public Player getPlayer(string playerID)
    {
        return players[playerID];
    }
    public bool hasPlayer(Player player)
    {
        return players.ContainsKey(player.getNetworkID());
    }

    public void setSaveTime(DateTime dateTime)
    {
        dateSaved = dateTime;
    }
    public DateTime getSaveTime()
    {
        return dateSaved;
    }

    public Dictionary<string, Player> getPlayerDict()
    {
        return players;
    }
    public GameState DeepCopy()
    {
        return SavedGameController.deserializeGameState(SavedGameController.serializeGameState(this));
    }

}
