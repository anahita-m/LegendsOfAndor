using System;
using UnityEngine;

[System.Serializable]
public class EndFight : Action
{
    string[] players;
    Type type;
//     Monster monster;
   
//    bool wonBattle;
    

    public EndFight(string[] players)
    {
        type = Type.EndFight;

        this.players = players;

        // this.monster = m;
        // wonBattle = won;
    }

    public string[] playersInvolved()
    {
        return this.players;
    }
    public Type getType()
    {
        return this.type;
    }

    public void execute(GameState gs)
    {
        
        foreach(string playerId in players){
            gs.getPlayer(playerId).getHero().usingHelm = false;
            gs.getPlayer(playerId).getHero().usingBow = false;
            gs.getPlayer(playerId).getHero().usingWitchBrew = false;
            gs.getPlayer(playerId).getHero().usingShield= false;

        }
        // if(wonBattle){
        //     monster.setCantMove();
        // }     
        Array.Clear(players, 0, players.Length);
        GameController.instance.fsc.fightOverAction();

    }

    public bool isLegal(GameState gs)
    {
        return true;
    }

   
}