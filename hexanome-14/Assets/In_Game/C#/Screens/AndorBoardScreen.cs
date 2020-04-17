using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndorBoardScreen : Screen
{

    public AndorBoardScreen(string name) : base(name)
    {
    }

    protected override bool canOpenScreen(string playerTag)
    {
        Debug.Log("----------------- Player with tag: " + playerTag + "requested to switch to :" + screenName + "-----------------------------------");
        return true;
    }

    protected override void addAllClickables()
    {

        Debug.Log("before add graph clickables " + screenName);
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
