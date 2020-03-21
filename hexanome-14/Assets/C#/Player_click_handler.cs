using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon.Pun;

namespace Andor{
public class Player_click_handler : MonoBehaviour
{
    // need to add this and command router and screenmanager scripts to the player prefab
    //
    // Start is called before the first frame update
    private CommandRouter commands;
    void Start()
    {
        // player = gameObject.GetComponent<Player>();
        CommandRouter commands = gameObject.GetComponent<CommandRouter>();
    }


    // pass in current screen as parameter
    public void checkClick(Vector3 currPos, Andor.Player player)
    {
        string clickedTag = getClickedGameObjectTag();
        if (clickedTag == "") return;

        Debug.Log("clicked tag is: " + clickedTag);
        List<string> clickables = player.screenManager.getClickables(player.currSceneTag());
        if (clickables == null)
        {
            Debug.Log("found null list of clickables in click handler");
            return;
        }
        if (!clickables.Contains(clickedTag))
            return;

        if (clickedTag == "Start-Fight")
        {
            string newScene ="fight-scene";
            player.changeOfScene(newScene);

            if (PhotonNetwork.IsMasterClient)
                PhotonNetwork.LoadLevel(newScene);
            return;
        }

        if (clickedTag == "Leave-battle")
        {
            string newScene ="AndorBoard";
            player.changeOfScene(newScene);

            if (PhotonNetwork.IsMasterClient)
                PhotonNetwork.LoadLevel(newScene);
            return;
        }



        // now hook this up to the commandRouter and we can check

        // Command cmd = commands
        // if (cmd.isLegal())
        // {
        //     cmd.execute();
        // }

        if (player.currSceneTag() == "AndorBoard")
        {

            Vector3 clickedPos = getClickedPos(clickedTag, clickables);
            Vector3 invalidFlag = new Vector3(-10000, 1, 1);

            // sets player.newPos = clickedPos if clickedPos is valid
            player.setNewPos((clickedPos != invalidFlag) ? clickedPos : currPos);
        }
        else
            Debug.Log("current scene is: " + player.currSceneTag());

        // always do this, makes movement go slowly not jump from one spot to nxt
        // GetComponent<Player>().moveToNewPos();
    }



    private Vector3 getClickedPos(string clickedTag, List<string> clickables)
    {
        /* later this will see if the clickedTag belongs to the current screen
            */
        foreach(string clickable in clickables)
        {
            if (clickable == clickedTag)
            {
                GameObject go = GameObject.FindWithTag(clickedTag);
                BoardPosition bp = go.GetComponent<BoardPosition>();

                Vector3 newPos = bp.getMiddle();
                return newPos;
            }
        }
        return new Vector3(-10000, 1, 1);


        // right now we just assume clicked a boardPosition
        // int cTag;
        // try
        // {
        //     cTag = int.Parse(clickedTag);
        //     GameObject go = GameObject.FindWithTag(clickedTag);
        //     BoardPosition bp = go.GetComponent<BoardPosition>();

        //     Vector3 newPos = bp.getMiddle();
        //     return newPos;

        //     // player.gameObject.transform.position = bp.getMiddle();
        //     // newPos = player.sphere.transform.position;
        //     // transform.position = new Vector3(-6.81f, 7.57f, 0.0f);
        // }
        // catch (InvalidCastException e)
        // {
        //     return new Vector3(-10000, 1, 1);
        // }
    }

    private string getClickedGameObjectTag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // RaycastHit hitInfo;
        RaycastHit2D hitInfo = Physics2D.GetRayIntersection(ray);
        if (!clickedClickableObj(hitInfo))
            return "";

        return hitInfo.collider.gameObject.tag;

    }


    private bool clickedClickableObj(RaycastHit2D hitInfo)
    {
        if (hitInfo == null)
            return false;
        else if (hitInfo.collider == null)
        {
            Debug.Log("hitInfo not null, collider is null");
            return false;
        }

        else if (hitInfo.collider.gameObject == null)
        {
            Debug.Log("hitInfo not null, collider.gameObject is null");
            return false;
        }

        else if (hitInfo.collider.gameObject.tag == "")
        {
            Debug.Log("hitInfo not null, collider.gameObject.tag is not set");
            return false;
        }
        return true;
    }

}
}
