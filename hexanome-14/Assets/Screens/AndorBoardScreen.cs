using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndorBoardScreen : Screen
{

    private ScreenManager screenManager;

    void Start()
    {
        screenManager = GameObject.FindWithTag("ScreenManager").GetComponent<ScreenManager>();
    }

    public void canSwitchScreens(string playerTag)
    {
        Debug.Log("----------------- Player with tag: " + playerTag + "requested to switch to :" + gameObject.tag + "-----------------------------------");
    }

    protected override void addAllClickables()
    {
        clickables = new List<string>();
        TurnManager tm = GameObject.FindWithTag("Master").GetComponent<TurnManager>();
        if (tm == null)
            Debug.Log("found null turnmanager is screenmanager");
        Graph g = BoardContents._singleton.graph;
        if (g == null)
            Debug.Log("graph is null :( ");
        if (g.nodes == null)
        {
            Debug.Log("foreign call to loadNeighbours!");
            g.loadNeighbours();
        }

        foreach(Node n in g.nodes)
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
