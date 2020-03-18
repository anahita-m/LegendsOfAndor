using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroBoards : MonoBehaviour
{
    private List<Hero> heroes;

    public HeroBoards(List<Hero> heroList)
    {

        this.heroes = heroList;
        foreach(Hero h in heroList)
        {
            this.heroes.Add(h);
        }
    }

    private void Update()
    {
        int i = 1;
        foreach(Hero h in heroes)
        {
            //display image of hero

            //display wp
            Text wp = GameObject.Find("Canvas/wp" + i).GetComponent<Text>();
            wp.text = "will power: " + h.getWillPower();

            //display strength
            Text strength = GameObject.Find("Canvas/strength" + i).GetComponent<Text>();
            strength.text = "strength: " + h.getStrength();
            //display gold
            Text gold = GameObject.Find("Canvas/gold" + i).GetComponent<Text>();
            gold.text = "strength: " + h.getGold();

        }
    }

}
