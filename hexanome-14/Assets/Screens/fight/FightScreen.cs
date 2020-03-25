using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightScreen : Screen
{

    private ScreenManager screenManager;

    void Start()
    {
        screenManager = (ScreenManager)FindObjectOfType(typeof(ScreenManager));
        // screenManager = GameObject.FindWithTag("ScreenManager").GetComponent<ScreenManager>();
    }

    public void canSwitchScreens(string playerTag)
    {
        Debug.Log("----------------- Player with tag: " + playerTag + "requested to switch to :" + gameObject.tag + "-----------------------------------");
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


    // private void addAlwaysClickable()
    // {
    //     TurnManager tm = GameObject.FindWithTag("master").GetComponent<TurnManager>();
    //     if (tm == null)
    //         Debug.Log("found null turnmanager is screenmanager");
    //     foreach(Node n in tm.boardContents.getNodes())
    //     {
    //         clickables.Add(n.getIndex().ToString());
    //     }
    //     // still need to add tags of buttons in this screen
    // }

}
