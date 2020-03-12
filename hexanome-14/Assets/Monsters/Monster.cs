using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour, Fightable, Movable
{
    private MoveStrategy moveStrat;
    private DiceRollStrategy diceRollStrat;
    private string myTag;
    private string heroType;

    private Monster myMonster;

    public void move(ref Node path)
    {
        moveStrat.move(ref path, this);
    }

    public void diceRoll()
    {
        diceRollStrat.roll(this);
    }

    //public void setTag(string ID)
    //{
    //    myTag = ID;
    //    gameObject.tag = ID;
    //    setMonsterType;
    //}

    public void setMonster(Monster monster)
    {
        myMonster = monster;
    }

    void Start()
    {

        myMonster = new Monster();
    }

}
