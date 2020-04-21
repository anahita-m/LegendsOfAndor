using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class FightScreen : Action
{
    private string[] players;
    private Type type;

    public FightScreen(string playerID)
    {
        type = Type.Fight;
        players = new string[] { playerID };
    }

    public void execute(GameState gs)
    {
        if (isFightable(gs) ==true)
        {
            SceneManager.LoadScene("FightScene");
            gs.turnManager.passTurn();
        }
        else
        {
            GameController.instance.updateGameConsoleText("Player cannot fight!");
        }
    }

    public Type getType()
    {
        return type;
    }

    public bool isLegal(GameState gs)
    {

        return players[0].Equals(gs.turnManager.currentPlayerTurn());
    }

    private bool isFightable(GameState gs)
    {
        
        int playerPosition;
        gs.playerLocations.TryGetValue(players[0],out playerPosition);
        Debug.Log("Player at: "+playerPosition);
        if (gs.gors.ContainsValue(playerPosition) || gs.skrals.ContainsValue(playerPosition))
        {
            Debug.Log("Monster same spot");
            return true;
        }
        else {
            return false;
        }

    }

    public string[] playersInvolved()
    {
        return players;
    }
}
