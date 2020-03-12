using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon.Pun;

namespace Andor{
public class Player_click_handler : MonoBehaviour
{
    private Player player;
    // Start is called before the first frame update
    void Awake()
    {
        if (photonView.IsMine)
            player = GetComponent<Player>();
    }

    public void checkClick(Vector3 currPos)
    {
        if (Input.GetMouseButtonDown(0))
        {
            string clickedTag = getClickedGameObjectTag();
            if (clickedTag == "") return;

            Vector3 clickedPos = getClickedPos(clickedTag);
            Vector3 invalidFlag = new Vector3(-10000, 1, 1);

            // sets player.newPos = clickedPos if clickedPos is valid
            player.setNewPos((clickedPos != invalidFlag) ? clickedPos : currPos);
        }

        // always do this, makes movement go slowly not jump from one spot to nxt
        player.moveToNewPos();
    }



    private Vector3 getClickedPos(string clickedTag)
    {
        /* later this will see if the clickedTag belongs to the current screen
            */

        // right now we just assume clicked a boardPosition
        int cTag;
        try
        {
            cTag = int.Parse(clickedTag);
            GameObject go = GameObject.FindWithTag(clickedTag);
            BoardPosition bp = go.GetComponent<BoardPosition>();

            Vector3 newPos = bp.getMiddle();
            return newPos;

            // player.gameObject.transform.position = bp.getMiddle();
            // newPos = player.sphere.transform.position;
            // transform.position = new Vector3(-6.81f, 7.57f, 0.0f);
        }
        catch (InvalidCastException e)
        {
            return new Vector3(-10000, 1, 1);
        }
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
