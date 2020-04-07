using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour, Movable, Fightable
{
    // private GameObject sphere;
    // private SpriteRenderer spriteRenderer;
    private string heroType;
    private string myTag;

    // this is the tag of the sphere gameObject which we show
    // as a hero's position! (currently the gray squished sphere)
    public string sphereTag;
    public string position;

    private MoveStrategy moveStrat;
    private DiceRollStrategy diceRollStrat;

    // don't care which farmers, just that this number exists on our space.
    private int numFarmers;
    private bool hasThorald;

    private int numHoursLeft;

    private int gold = 2;

    // all heroes start with 1 strength point
    private int strength = 1;
    // all heroes start with 7 willPower points
    private int willPower = 7;
    // rank differs per hero so initialize this in child classes.
    private int rank;


    // use List not ArrayList -- see microsoft docs on arraylist
    private List<merchArticle> myArticles = new List<merchArticle>();

    // Will need to use this to verify things like: 
    // showTradeRequest() { if player.lookingAt != Battle then showTradeRequest() }
    // private Screen lookingAt;


    // called AFTER gameObject for this script has been created
    // AND the necessary components have been added.

    public void Start()
    {
        
    }

    //public Hero(string mySphereTag, string thisMyTag)
    //{
    //    myTag = thisMyTag;
    //    heroType = myTag;

    //    // need to keep track of this things location.
    //    sphereTag = mySphereTag;
    //}
    public void init(string mySphereTag, string thisMyTag)
    {
        myTag = thisMyTag;
        heroType = myTag;

        // need to keep track of this things location.
        sphereTag = mySphereTag;
    }

    public string getSphereTag()
    {
        // this allows a moveStrategy to do:
        // GameObject sphere = GameObject.FindWithTag(hero.getSphereTag());
        // sphere.transform = newPosition;
        return sphereTag;

        // NOTE: maybe we don't need to think about sphere's..
        // maybe since the sphere is a child this hopefully means that moving
        // the hero object should move the child sphere which shows their location
    }

    public void move(ref Node path)
    {
        moveStrat.move(ref path, this);
    }

    public void diceRoll()
    {
        diceRollStrat.roll(this);
    }

    
    public int getGold()
    {
        return gold;
    }
    public void setGold(int gold)
    {
        this.gold = gold;
    }

    //void OnMouseOver()
    //{
    //    int g = this.getGold();
    //    Debug.Log("Player has: " + g);
    //}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)){
            int g = this.getGold();
            Debug.Log("Player has: " + g);
        }
    }

    public int getStrength()
    {
        return this.strength;

    }

    public void setStrength(int strength)
    {
        this.strength = strength;
    }

    public int getWillPower()
    {
        return this.willPower;
    }

    public void addArticle(merchArticle ar)
    {
        this.myArticles.Add(ar);
    }

    //MERCHANT METHODS
    public bool onMerchant;

    public void setOnMerchant(bool onMerchant)
    {
        this.onMerchant = onMerchant;
    }



    public void buyArticle(string article)
    {
        //Debug.Log("Player current list " + articleList());
        merchArticle ar = Article.stringToArticle(article);
        if (this.gold >= 2)
        {
            this.gold -= 2;

            this.addArticle(ar);
        }
        Debug.Log("Player new list " + articleList());
        //Debug.Log("Player gold " + this.gold);
        
    }

    //bought from merchant
    public void buyStrength()
    {
        

        if (this.gold >= 2)
        {
            //decrease gold
            this.gold -= 2;

            //increase strength
            this.strength += 1;

        }
        Debug.Log("Player buying strength");
        Debug.Log("Player gold " + this.gold);
        Debug.Log("Player strength " + this.strength);


    }

    //private string articleList()
    //{
    //    string arList = "";

    //    foreach (merchArticle ar in myArticles)
    //    {
    //        arList += (" " + ar.ToString());
    //    }
    //    arList += "\n";
    //    return arList;

    //}

    private string articleList()
    {
        Dictionary<merchArticle, int> quantityArticles = new Dictionary<merchArticle, int>();
        
        foreach (merchArticle ar in myArticles)
        {
            int count = 0;
            if (quantityArticles.TryGetValue(ar, out count))
            {
                count++;
                quantityArticles[ar] = count;
            }
            else
            {
                quantityArticles.Add(ar, 1);
            }
        }

        string arList = "";
        int i = 0;
        int size = quantityArticles.Values.Count;
        foreach(merchArticle ar in quantityArticles.Keys)
        {
            
            int qty = 0;
            if(quantityArticles.TryGetValue(ar, out qty))
            {
                string addString = "";
                
                arList += (qty.ToString() + "x " + ar.ToString());
                if (i < size - 1)
                {
                    arList += ", ";
                }
                i++;
            }
            
        }

        return arList;

    }

}
