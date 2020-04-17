﻿using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

[System.Serializable]
[JsonObject(MemberSerialization.Fields)]
public class Hero // : MonoBehaviour, Movable, Fightable
{
    // private GameObject sphere;
    // private SpriteRenderer spriteRenderer;
    private string
        heroType = "";
    private string myTag;
    private string[] pronouns;

    // this is the tag of the sphere gameObject which we show
    // as a hero's position! (currently the gray squished sphere)
    private string sphereTag;

    //private MoveStrategy moveStrat;
    //private DiceRollStrategy diceRollStrat;

    // don't care which farmers, just that this number exists on our space.
    private int numFarmers;
    private bool hasThorald;
    private int heroRank;


    private int gold = 2;
    private int strength = 0;
    private int willpower = 0;

    private int hour = 0;
    private List<string> articles = new List<string>();
    private int gemstones = 0;

    public Hero()
    {
        articles.Add("test1");
        articles.Add("test2");
        pronouns = new string[3];
    }

    public int getGold()
    {
        return gold;
    }
    public void setGold(int gold)
    {
        this.gold = gold;
    }
    public void increaseGold(int gold)
    {
        this.gold += gold;
    }

    public int getStrength()
    {
        return strength;
    }
    public void setStrength(int strength)
    {
        this.strength = strength;
    }
    public void increaseStrength(int strength)
    {
        this.strength += strength;
    }
    public int getWillpower()
    {
        return willpower;
    }
    public void setWillpower(int willpower)
    {
        this.willpower = willpower;
    }
    public void increaseWillpower(int willpower)
    {
        this.willpower += willpower;
    }
    public int getHour()
    {
        return hour;
    }
    public void setHour(int hour)
    {
        this.hour = hour;
    }

    public string getHeroType()
    {
        return heroType;
    }
    public void setHeroType(string hero)
    {
        this.heroType = hero;

        if (hero.StartsWith("Male"))
        {
            pronouns[0] = "he";
            pronouns[1] = "him";
            pronouns[2] = "his";
        }

        if (hero.StartsWith("Female"))
        {
            pronouns[0] = "she";
            pronouns[1] = "hers";
            pronouns[2] = "her";
        }

    }

    public int getHeroRank()
    {
        return heroRank;
    }
    public void setHeroRank(int rank)
    {
        this.heroRank = rank;

    }

    public string[] getPronouns()
    {
        return this.pronouns;
    }

    public List<string> getArticles()
    {
        return this.articles;
    }

    public int getGemstone()
    {
        return this.gemstones;
    }

    public void addArticle(string article)
    {
        this.articles.Add(article);
    }

    public void removeArticle(string article)
    {
        this.articles.Remove(article);
    }

    public string allArticles()
    {
        string s_articles = "";
        foreach(string ar in this.articles)
        {
            s_articles += (ar + " ");
        }
        return s_articles;
    }

    public void incGold()
    {
        this.gold++;
    }

    public void decGold()
    {
        this.gold--;
    }
}
