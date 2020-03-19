using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightScreen : Screen
{

    void Start()
    {
        screenManager = GameObject.FindWithTag("ScreenManager").GetComponent<ScreenManager>();
        addAllClickables();
    }

    public void addAllClickables()
    {
        // each button's gameObject tag is the buttons displayed text with spaces replaced with '-'
        foreach(string s in new string[] { "roll-dice", "leave-battle", "exit-game" })
        {
            clickables.Add(s);
        }
    }


    private void addSometimesClickable()
    {
        int x = 0;
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
