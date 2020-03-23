using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

public class BoardContents : Graph
{

    /* This class inherits graph, a class which provides basic functions
     * for querying distance between positions on the board.
     *
     * The purpose of this child class is to do ^ operations
     * and store per position information such as the locations
     * of all wells, players.
     * */

    // store: (player tag, current boardPosition tag) for each player to keep track of their positions
    private Dictionary<string, string> playerPositions;
    private Dictionary<string, string> monsterPositions;
    private Dictionary<string, string> skralPositions;
    private Dictionary<string, string> gorPositions;
    private Dictionary<string, string> trollPositions;
    private Dictionary<string, string> wardakPositions;


    private static BoardContents _singleton;

    // wanted to use arraylist but the microsoft docs say it sucks, recommended this.
    // private List<Usable> articlesOnPos;
    // this should be a dictionary: <int, List<Usable>>

    private bool initialized = false;

    public static BoardContents getInstance
    {
        get { return _singleton; }
    }


    // called when a script with this object attached is loaded (before Start())
    private void Awake()
    {
        if (_singleton != null && _singleton != this)
        {
        // only allow one gameObject with this script as a component
            Destroy(this.gameObject);
            return;
        }

        _singleton = this;
        // this allows this gameObject to persist between different scenes.
//        DontDestroyOnLoad(this.gameObject);
    }



    // this private constructor just calls the superclass constructor
    private BoardContents() : base()
    {
    }

    public static BoardContents initAndGetPlayers(Dictionary<string, string> playerPos)
    {
        _singleton.initPlayer(playerPos);
        return _singleton;
    }

    public static string getPlayerPosition(string playerTag)
    {
        return _singleton.playerPositions[playerTag];
    }

    public static Dictionary<string, string> getAllPlayerPositions()
    {
        return _singleton.playerPositions;
    }

    public static void setNewPlayerPosition(string playerTag, string posTag)
    {
        _singleton.playerPositions[playerTag] = posTag;
    }


    private void initPlayer(Dictionary<string, string> playerPos)
    {
        playerPositions = playerPos;
        initialized = true;
    }

    //**********************************************************************************


    public static BoardContents initAndGetMonster(Dictionary<string, string> monsterPositions)
    {
        _singleton.initMonster(monsterPositions);
        return _singleton;
    }

    public static string getMonsterPosition(string monsterTag)
    {
        return _singleton.monsterPositions[monsterTag];
    }


    public static void setNewMonsterPosition(string monsterTag, string monsterPos)
    {
        _singleton.monsterPositions[monsterTag] = monsterPos;
    }

    public static Dictionary<string, string> getAllMonsterPositions()
    {
        return _singleton.monsterPositions;
    }


    private void initMonster(Dictionary<string, string> monsterPos)
    {
        monsterPositions = monsterPos;
        initialized = true;
    }

    //**********************************************************************************

    public static BoardContents initAndGetSkral(Dictionary<string, string> skralPositions)
    {
        _singleton.initSkral(skralPositions);
        return _singleton;
    }

    public static string getSkralPosition(string skralTag)
    {
        return _singleton.skralPositions[skralTag];
    }


    public static void setNewSkralPosition(string skralTag, string skralPos)
    {
        _singleton.skralPositions[skralTag] = skralPos;
    }

    public static Dictionary<string, string> getAllSkralPositions()
    {
        return _singleton.skralPositions;
    }


    private void initSkral(Dictionary<string, string> skralPos)
    {
        skralPositions = skralPos;
        initialized = true;
    }

    //***********************************************************************************

    public static BoardContents initAndGetGor(Dictionary<string, string> gorPositions)
    {
        _singleton.initGor(gorPositions);
        return _singleton;
    }

    public static string getGorPosition(string gorTag)
    {
        return _singleton.gorPositions[gorTag];
    }


    public static void setNewGorPosition(string gorTag, string gorPos)
    {
        _singleton.skralPositions[gorTag] = gorPos;
    }

    public static Dictionary<string, string> getAllGorPositions()
    {
        return _singleton.gorPositions;
    }

    private void initGor(Dictionary<string, string> gorPos)
    {
        gorPositions = gorPos;
        initialized = true;
    }

    //***********************************************************************************************
    // the ienumerable just allows me to do:
    // foreach(KeyValuePair<string, string> kvp in boardContents.getPlayerPos())
    // in the turnmanager class
    public IEnumerable<KeyValuePair<string, string>> getPlayerPos()
    {
        foreach(KeyValuePair<string, string> kvp in playerPositions)
        {
            yield return kvp;
        }
    }


    public IEnumerable<KeyValuePair<string, string>> getSkralPos()
    {
        foreach (KeyValuePair<string, string> kvp in skralPositions)
        {
            yield return kvp;
        }
    }

    public IEnumerable<KeyValuePair<string, string>> getGorPos()
    {
        foreach (KeyValuePair<string, string> kvp in gorPositions)
        {
            yield return kvp;
        }
    }
}
