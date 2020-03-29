using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class timeTracker : MonoBehaviourPun
{

    static Vector3 archPosSunrise = new Vector3(-6.13f, 29.90f, 0f);
    static Vector3 wizPosSunrise = new Vector3(-8.13f, 29.90f, 0f);
    static Vector3 warPosSunrise = new Vector3(-10.13f, 29.90f, 0f);
    static Vector3 dwarfPosSunrise = new Vector3(-12.13f, 29.90f, 0f);
    static Vector3 hour1 = new Vector3(-12.13f, 29.90f, 0f);
    static Vector3 hour2 = new Vector3(-15.13f, 29.90f, 0f);
    static Vector3 hour3 = new Vector3(-18.13f, 29.90f, 0f);
    static Vector3 hour4 = new Vector3(-21.13f, 29.90f, 0f);
    static Vector3 hour5 = new Vector3(-24.13f, 29.90f, 0f);
    static Vector3 hour6 = new Vector3(-27.13f, 29.90f, 0f);
    static Vector3 hour7 = new Vector3(-30.13f, 29.90f, 0f);
    static Vector3 hour8 = new Vector3(-33.13f, 29.90f, 0f);
    static Vector3 hour9 = new Vector3(-36.13f, 29.90f, 0f);
    static Vector3 hour10 = new Vector3(-39.13f, 29.90f, 0f);

    public static int hour;
	public static GameObject tracker;

	public static int getHour()
	{
		return hour;
	}

    public void setHour(int h)
	{
        hour = h;
        if(h == 1)
        {
            tracker.transform.position = hour1;

        }
        if (h == 2)
        {
            tracker.transform.position = hour2;

        }
        if (h == 3)
        {
            tracker.transform.position = hour3;

        }
        if (h == 4)
        {
            tracker.transform.position = hour4;

        }
        if (h == 5)
        {
            tracker.transform.position = hour5;

        }
        if (h == 6)
        {
            tracker.transform.position = hour6;

        }
        if (h == 7)
        {
            tracker.transform.position = hour7;

        }
        if (h == 8)
        {
            tracker.transform.position = hour8;

        }
        if (h == 9)
        {
            tracker.transform.position = hour9;

        }
        if (h == 10)
        {
           tracker.transform.position = hour10;

        }
        //if (checkEndOfDay())
        //{
        //    //method for sunrise box
        //}
    }

	public bool checkEndOfDay(){
		int i = 0;
		foreach (string player in GameManager.playerTagList)
       {	
           if (GameObject.FindGameObjectWithTag(player).GetComponent<Player>().getHour() == "0") {
           	i++;
           }
       }
       if (i == PhotonNetwork.PlayerList.Length){
       	return true;
       }
       else{
       	return false;
       }
	}

    public void sunrise()
    {
        GameConsole.instance.UpdateFeedback("A new day has begun!");
        //EventCard.revealTopEventCard();
        Monster.moveAllMonstersAtSunrise();
        //Wells.refreshAllWells();
        //Narrator.AdvanceNarrator();

    }
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
