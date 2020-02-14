using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private string userName;

    // ie Player-Male-Dwarf
    // also encodes the corresponding hero type
    private string myTag;
    private string heroType;
    private Hero myHero;


    public void setTag(string ID)
    {
        myTag = ID;
        setHeroType();
        myHero = new Archer();
    }

    public string getPlayerTag()
    {
        return myTag;
    }

    public string getHeroType()
    {
        return heroType;
    }

    void Update()
    {
        // ie left-click
        if (Input.GetMouseButtonDown(0))
        {
            masterClass master = gameObject.GetComponentInParent<masterClass>();
            master.notifyClick();
        }
    }

    // extracts the hero tag from our own tag
    // EX.)   if (myTag == "Player-Male-Dwarf") -> output "Male-Dwarf"
    private void setHeroType()
    {
        // must initialize before adding strings
        heroType = "";
        int ct = 0;
        foreach(string partOfTag in myTag.Split('-'))
        {
            // skip first val: "Player"
            if (ct++ == 0) continue;

            heroType += partOfTag;
        }
    }


}
