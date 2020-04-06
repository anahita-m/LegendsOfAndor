using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Inventory 
{
    private static readonly Inventory INSTANCE = new Inventory();
    private Dictionary<merchArticle, List<merchArticle>> store = new Dictionary<merchArticle, List<merchArticle>>();

    public Inventory()
    {
        
        //4 shield
        this.addArticles(merchArticle.Shield, 4);
        //3 bow
        this.addArticles(merchArticle.Bow, 3);
        //2 falcon
        this.addArticles(merchArticle.Falcon, 2);
        //5 wineskin
        this.addArticles(merchArticle.Wineskin, 5);
        //2 telescope
        this.addArticles(merchArticle.Telescope, 2);
        //5 witch's brew
        this.addArticles(merchArticle.WitchBrew, 5);
        //3 helm
        this.addArticles(merchArticle.Helm, 3);
    }

    //helper method for adding quantities
    private void addArticles(merchArticle item, int quantity)
    {
        
        List<merchArticle> ars = new List<merchArticle>();
        for (int i = 0; i < quantity + 1; i++)
        {
            
            ars.Add(item);

        }
        store.Add(item, ars);
    }

    public static Inventory getInstance()
    {
        
        //Debug.Log("size of store " + store.Values.Count);
        return INSTANCE;
    }

    //helper method
    public void removeItem(merchArticle ar)
    {
        //Debug.Log("BEFORE");
        //listInventory();
        //Debug.Log("removing " + ar.ToString());
        //@TODO: this might need to get done in a database
        foreach (List<merchArticle> items in store.Values)
        {
            if (items[0].Equals(ar))
            {
                items.Remove(ar);
            }
        }
        //Debug.Log("AFTER");
        //listInventory();
    }

    public void listInventory()
    {
        List<merchArticle> shieldArs;

        if(store.TryGetValue(merchArticle.Shield, out shieldArs))
        {
            Debug.Log("Remaining shields " + shieldArs.Count);
        }

        List<merchArticle> falconArs;

        if (store.TryGetValue(merchArticle.Falcon, out falconArs))
        {
            Debug.Log("Remaining falcons " + falconArs.Count);
        }

    }

    public Dictionary<merchArticle, List<merchArticle>> getStore()
    {
        return store;
    }
}
