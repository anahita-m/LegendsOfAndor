using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum merchArticle
{
    Shield, Bow, Falcon, Wineskin, Telescope, WitchBrew, Helm
}; 
public class Article: MonoBehaviour
{
	private int id;
    private merchArticle item;

    public void Start()
    {

        


    }

    public static merchArticle stringToArticle(string ar)
    {
        if (ar.Equals("Shield")) return merchArticle.Shield;
        if (ar.Equals("Bow")) return merchArticle.Bow;
        if (ar.Equals("Falcon")) return merchArticle.Falcon;
        if (ar.Equals("Wineskin")) return merchArticle.Wineskin;
        if (ar.Equals("Telescope")) return merchArticle.Telescope;
        if (ar.Equals("WitchBrew")) return merchArticle.WitchBrew;
        if (ar.Equals("Helm")) return merchArticle.Helm;

        return merchArticle.Shield;
    }

    public Article(merchArticle item)
    {
        this.item = item;
    }

    public void setItem(merchArticle item)
    {
        this.item = item;
    }


    public merchArticle getArticle()
    {
        return this.item;
    }


    public string getArticleName()
    {
        return this.item.ToString();
    }

    
}