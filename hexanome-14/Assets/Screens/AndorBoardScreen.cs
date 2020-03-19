using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndorBoardScreen : Screen
{

    void Start()
    {
        screenManager = GameObject.FindWithTag("ScreenManager").GetComponent<ScreenManager>();
        addAllClickables();
    }


    public void canSwitchScreens(string playerTag)
    {
        Debug.Log("----------------- Player with tag: " + playerTag + "requested to switch to :" + gameObject.tag + "-----------------------------------");
    }

    private void addAllClickables()
    {
        TurnManager tm = GameObject.FindWithTag("master").GetComponent<TurnManager>();
        if (tm == null)
            Debug.Log("found null turnmanager is screenmanager");
        foreach(Node n in tm.boardContents.getNodes())
        {
            clickables.Add(n.getIndex().ToString());
        }
        // still need to add tags of buttons in this screen
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
