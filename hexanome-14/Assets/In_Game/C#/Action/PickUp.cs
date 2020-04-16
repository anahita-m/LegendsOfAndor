using System;
using UnityEngine;

[System.Serializable]
public class PickUp : Action
{
    private Type type;
    private string[] players;

    public PickUp()
    {
    }
    public Type getType(){
        return type;

    }
    public string[] playersInvolved(){
        return players;
    }

    public bool isLegal(GameState gs){
        return true;

    }
    public void execute(GameState gs){
        Debug.Log("Action Executed");
    }
}
