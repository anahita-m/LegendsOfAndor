using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndorBoardScreen : Screen
{

    private ScreenManager screenManager;

//     public void onSwitch()
//     {
//         if (clickables == null)
//         {
//             Debug.Log("add all clickables");
//             addAllClickables();
//         }
//     }

    public override void init()
    {
        screenManager = (ScreenManager)FindObjectOfType(typeof(ScreenManager));
        Debug.Log("in start fxn of andorscreen");
    }


    void Start()
    {
        screenManager = (ScreenManager)FindObjectOfType(typeof(ScreenManager));
        Debug.Log("in start fxn of andorscreen");
        // screenManager = GameObject.FindWithTag("ScreenManager").GetComponent<ScreenManager>();
    }

    public void canSwitchScreens(string playerTag)
    {
        Debug.Log("----------------- Player with tag: " + playerTag + "requested to switch to :" + gameObject.tag + "-----------------------------------");
    }

    protected override void addAllClickables()
    {
        Debug.Log("sdaskdndsd sadkjfk akdjasf ask");
        clickables = new List<string>();
        TurnManager tm = GameObject.FindWithTag("Master").GetComponent<TurnManager>();
        if (tm == null)
            Debug.Log("found null turnmanager is screenmanager");
        Graph g = BoardContents._singleton;
        // if (g == null)
        //     Debug.Log("graph is null :( ");
        // if (Graph.nodes == null)
        // {
            Debug.Log("foreign call to loadNeighbours!");
            g.loadNeighbours();
        // }

        Debug.Log("before add graph clickables");
        Node[] nodes = Graph.nodes;
        foreach(Node n in nodes)
        {
            if( BoardContents._singleton.GetComponent<BoardContents>() == null)
                Debug.Log("singleton is null :(");
            // if (BoardContents._singleton.GetComponent<BoardContents>())

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
