﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well
{
    private Node location;
    public bool used;
    protected GameObject prefab;

    public Well(Node startingPos, GameObject prefab)
    {
        location = startingPos;
        this.prefab = prefab;
        used = false;
    }

    private Well() { }

    public void emptyWell()
    {
        //this.prefab =
        
        this.used = true;
        //this.prefab.GetComponent<Material>().color = Color.gray;
        //this.prefab.GetComponent<Renderer>().enabled = false ;
    }

    public void refreshWell()
    {
        this.used = false;
    }

    public int getLocation()
    {
        return location.getIndex();
    }

    public void setLocationNode(Node x)
    {
        location = x;
    }

    public Node getLocationNode()
    {
        return location;
    }

    public GameObject getPrefab()
    {
        return prefab;
    }

}
