using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndorBoardScreen : Screen
{

    public AndorBoardScreen(string name) : base(name)
    {
    }

    public override void preSwitchSceneActions()
    {

    }

    // probably don't need to use this for this scene since this would just do the stuff
    // that gameController currently does for button clicks.
    // but if we ever want to, can clean up gameController and move all click stuff here.
    public override void executeIfLegal(string buttonName)
    {
        //switch(buttonName)
        //{
        //    case
        //}
    }


    public override bool canOpenScreen(string playerID)
    {
        // playerID is their networkID
        Debug.Log("----------------- Player with networkID: " + playerID + " requested to switch to :" + screenName + "-----------------------------------");
        return true;
    }

    protected override void addAllClickables()
    {

        Debug.Log("before add graph clickables " + screenName);
        if (clickables == null)
            clickables = new List<string>();
        foreach(Node n in Game.positionGraph)
        {

            if (n == null)
            {
                Debug.Log("null node found in andorboardscreen");
                continue;
            }
            string toAdd = n.getIndex().ToString();
            clickables.Add(toAdd);
        }
        clickables.Add("Start-Fight");
        // still need to add tags of buttons in this screen
        Debug.Log("AFTER add graph clickables");
    }
}
