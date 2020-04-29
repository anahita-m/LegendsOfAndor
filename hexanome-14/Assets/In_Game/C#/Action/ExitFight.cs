using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFight : Action
{
    private Type type;
    private string[] players;

    public ExitFight(string playerID)
    {
        type = Type.ExitFight;
        players = new string[] { playerID };
    }

    public Type getType()
    {
        return type;
    }

    public string[] playersInvolved()
    {
        return players;
    }


    public bool isLegal(GameState gs)
    {
        return true;
    }

    public void execute(GameState gs)
    {
        gs.getPlayer(players[0]).getHero().inBattle = false;
        gs.getPlayer(players[0]).getHero().usingBow = false;
        gs.getPlayer(players[0]).getHero().usingHelm = false;
        gs.getPlayer(players[0]).getHero().usingShield = false;
        gs.getPlayer(players[0]).getHero().usingWitchBrew = false;
        gs.getPlayer(players[0]).getHero().selectedArticle = false;
        Debug.Log("reset all battle checks");

    }
}
