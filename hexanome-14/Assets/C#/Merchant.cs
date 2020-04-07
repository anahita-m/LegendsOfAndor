using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Merchant : MonoBehaviour
{
    
    //private Dictionary<merchArticle, List<Article>> store = new Dictionary<merchArticle, List<Article>>();
    private Inventory inventory = Inventory.getInstance();
    private string position;
    //private List<Andor.Player> clients = new List<Andor.Player>();
    private string[] positions = {"18",
            "57",
            "71" };
    private Hero myClient;
    private static List<GameObject> gameBoardPos = new List<GameObject>();
    private Button merchButton;
    private static string currentSale = "";


    public void Start()
    {
        inventory = Inventory.getInstance();
        for (int i = 0; i <= 84; i++)
        {
            GameObject pos = GameObject.Find("position-" + i);
            if (pos != null)
            {
                //pos.SetActive(true);
                gameBoardPos.Add(pos);
            }

        }
        GameObject parent = GameObject.Find("Canvas");
        GameObject merchButtonObj = FindObject(parent, "MerchantButton");
        merchButton = merchButtonObj.GetComponent<Button>();
        merchButton.interactable = false;
        //Debug.Log("button is " + merchButton.interactable);

    }

    public bool sameLocation(string position)
    {
        //Debug.Log("Play pos " + position);
        foreach(string pos in this.positions)
        {
            if (pos.Equals(position))
            {
                return true;
            }
        }

        return false;
    }

    public void Update()
    {
        //Debug.Log("LENGTH " + gameBoardPos.Count);
        var heroes = FindObjectsOfType(typeof(Hero));
        //Debug.Log("num heroes " + heroes.Length);
        //if(myClient != null)
        //{
        //    Debug.Log("a client!");
        //}

        foreach (Hero hero in heroes)
        {
            if(sameLocation(hero.position))
            {
                //@TODO: and also player should qualify for isMine
                merchButton.interactable = true;
                hero.setOnMerchant(true);
                //clients.Add(player);
                
            }
            else
            {
                merchButton.interactable = false;
                hero.setOnMerchant(false);
            }
        }

    }

   

    public GameObject FindObject(GameObject parent, string name)
    {
        Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            //print("!!!!!!t.name " + t.name);
            if (t.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }

    //should be called on a merchant button click
    public void loadAvailItems(/*Andor.Player player*/)
    {
        Debug.Log("num photo players " + GameSetupController.playerObjects.Count);
        foreach(GameObject playerObject in GameSetupController.playerObjects)
        {
            Hero hero_cmpnt = playerObject.GetComponent<Hero>();
            Andor.Player player_cmpnt = playerObject.GetComponent<Andor.Player>();
            if(hero_cmpnt.onMerchant && player_cmpnt.isMine())
            {
                myClient = hero_cmpnt;
            }
        }
        

        GameObject parent = GameObject.Find("Canvas");
        GameObject merchBoard = FindObject(parent, "MerchantBoard");

        merchBoard.SetActive(true);

        //@TODO: need to make the rest of the board buttons uninteractable

        //Debug.Log("player " + player.myTag);
        Dictionary<merchArticle, List<merchArticle>> store = inventory.getStore();
        if(myClient == null)
        {
            Text goldText = GameObject.Find("Canvas/MerchantBoard/hero-gold").GetComponent<Text>();
            goldText.text = "You must be on the same space as the merchant to buy from the merchant";
            //Debug.Log("NUM articles " + store.Values.Count);
            foreach (List<merchArticle> articles in store.Values)
            {
                //Debug.Log("ARTICLE" + articles[0].ToString());
                Button articleButton = GameObject.Find(articles[0].ToString()).GetComponent<Button>();
                articleButton.interactable = false;
            }

            Button strengthButton = GameObject.Find("Strength").GetComponent<Button>();
            strengthButton.interactable = false;
        }
        else
        {

            //myClient = player;
            int heroGold = myClient.getGold();
            Text goldText = GameObject.Find("Canvas/MerchantBoard/hero-gold").GetComponent<Text>();
            goldText.text = "Gold Coins: " + heroGold;
            foreach (List<merchArticle> articles in store.Values)
            {
                //Debug.Log("Remaining " + articles[0].ToString() + ": "+ articles.Count);
                if (articles.Count == 1)
                {
                    //item out of stock
                    Button articleButton = GameObject.Find(articles[0].ToString()).GetComponent<Button>();
                    articleButton.GetComponentInChildren<Text>().text = articles[0].ToString() + " SOLD OUT";
                    //disable button corresponding to item
                    articleButton.interactable = false;
                }
                else if (heroGold < 2)
                {
                    //hero can't afford item
                    Button articleButton = GameObject.Find(articles[0].ToString()).GetComponent<Button>();

                    //disable button corresponding to item
                    articleButton.interactable = false;
                    Button strengthButton = GameObject.Find("Strength").GetComponent<Button>();
                    strengthButton.interactable = false;

                }
                else
                {
                    Button articleButton = GameObject.Find(articles[0].ToString()).GetComponent<Button>();

                    articleButton.interactable = true;
                }
            }
            


        }
        //Debug.Log("getting here");
        for (int i = 0; i <= 84; i++)
        {
            GameObject pos = GameObject.Find("position-" + i);
            if (pos != null)
            {
                pos.SetActive(false);
                //gameBoardPos.Add(pos);
            }

        }
        //Debug.Log("after deactivting: " + gameBoardPos.Count);


    }

    public void pleaseConfirm(string item)
    {
        //Debug.Log("CONFIRMING");
        currentSale = item;
        GameObject parent = GameObject.Find("MerchantBoard");
        GameObject confirmBoard = FindObject(parent, "Confirm");
        confirmBoard.SetActive(true);
        Text confirmText = GameObject.Find("Canvas/MerchantBoard/Confirm/ConfirmText").GetComponent<Text>();
        confirmText.text = "Would you like to buy " + item + " for 2 gold coins?";
    }

    public void clickOk()
    {
        Debug.Log("CLICKING OK");
        Debug.Log("currentSale " + currentSale);
        if (currentSale.Equals("Strength"))
        {
            this.sellStrength();
        }
        else {
            this.sellItem(currentSale);
        }
        
        GameObject parent = GameObject.Find("MerchantBoard");
        GameObject confirmBoard = FindObject(parent, "Confirm");
        confirmBoard.SetActive(false);
    }

    public void back()
    {
        Debug.Log("CLICKING BACK");
        GameObject parent = GameObject.Find("MerchantBoard");
        GameObject confirmBoard = FindObject(parent, "Confirm");
        confirmBoard.SetActive(false);
        loadAvailItems();
    }
    
    //called on an item button click
    public void sellItem(string article)
    {
        //Debug.Log("Merchant selling " + article);
        merchArticle ar = Article.stringToArticle(article);
        inventory.removeItem(ar);
        //player buys item
        var heroes = FindObjectsOfType(typeof(Hero));
        //Debug.Log("hero length " + heroes.Length);
        foreach (Hero h in heroes)
        {
            //Debug.Log("hero pos " + h.position);
            if (/*h.isMine() &&*/ h.onMerchant)
            {
                myClient = h;
                break;
            }
        }
        myClient.buyArticle(article);
        //update the board
        loadAvailItems();
        

    }
   
    //called on a strength button click
    public void sellStrength()
    {
        
        var heroes = FindObjectsOfType(typeof(Hero));
        
        foreach (Hero h in heroes)
        {
            if (/*h.isMine() &&*/ h.onMerchant)
            {
                myClient = h;
                break;
            }
        }
        myClient.buyStrength();

        //update the board
        this.loadAvailItems();

    }
    //public void setPosition(string position)
    //{
    //    this.position = position;
    //}

    public void closeBoard()
    {
        
        foreach (GameObject pos in gameBoardPos)
        {
            
            if (pos != null)
            {

                pos.SetActive(true);
                //Debug.Log("position " + " is " + pos.active);
            }

        }
        GameObject parent = GameObject.Find("Canvas");
        GameObject merchBoard = FindObject(parent, "MerchantBoard");
        merchBoard.SetActive(false);
        myClient = null;
        currentSale = "";
       


    }

    
   

}