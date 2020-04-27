using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightScreen : Screen
{
    //NOTE: the gameController object doesn't exist for this scene.
    public FightScreen(string name) : base(name)
    {
    }

    public override bool canOpenScreen(string playerID)
    {
        // playerID is their networkID
        Debug.Log("----------------- Player with networkID: " + playerID + " requested to switch to :" + screenName + "-----------------------------------");
        return true;
    }

    // here we will show popup to invite other players.
    public override void preSwitchSceneActions()
    {

    }

    protected override void addAllClickables()
    {
        // each button's gameObject tag is the buttons displayed text with spaces replaced with '-'
        clickables = new List<string>();
        foreach(string s in new string[] { "RollDiceTop", "RollDiceBottom", "LeaveBattleButton", "PauseMenuButton", "TradeButton", "PassButton"})
        {
            clickables.Add(s);
        }
    }


    public override void executeIfLegal(string buttonName)
    {
        // button name is the name (NOT TAG) of the gameObject which contains the clicked button
        switch(buttonName)
        {
            case "RollDiceTop":
                Debug.Log("roll dice top clicked");
                break;

            case "RollDiceBottom":
                Debug.Log("roll dice bottom clicked");
                break;

            case "LeaveBattleButton":
                Debug.Log("leave battle clicked");
                if (LeaveBattle.isLegal())
                    LeaveBattle.execute();
                break;

            case "PauseMenuButton":
                Debug.Log("pause menu button clicked");
                break;

            case "TradeButton":
                Debug.Log("trade clicked.");
                break;

            case "PassButton":
                Debug.Log("pass button clicked.");
                break;

            default:
                Debug.Log("unexpected button tag given to fightScreen.executeIfLegal");
                break;
        }
    }



}


// this is just here as a template, can add condition checks as needed.
public class LeaveBattle
{

    public static bool isLegal()
    {
        return true;
    }

    public static void execute()
    {
        // Debug.Log("about
        Debug.Log("in execute of LeaveBattle");
        ScreenManager.sceneSwitch("Game", "nada");
    }

}
