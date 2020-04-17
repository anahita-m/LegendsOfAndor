using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightScreen : Screen
{

    public FightScreen(string name) : base(name)
    {
    }

    protected override bool canOpenScreen(string playerTag)
    {
        Debug.Log("----------------- Player with tag: " + playerTag + "requested to switch to :" + screenName + "-----------------------------------");
        return true;
    }


    protected override void addAllClickables()
    {
        // each button's gameObject tag is the buttons displayed text with spaces replaced with '-'
        clickables = new List<string>();
        foreach(string s in new string[] { "Roll-dice", "Leave-battle", "Exit-game" })
        {
            clickables.Add(s);
        }
    }

}
