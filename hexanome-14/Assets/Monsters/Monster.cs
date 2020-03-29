using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class Monster : MonoBehaviourPun, Fightable
{
    private MoveStrategy moveStrat;
    private DiceRollStrategy diceRollStrat;
    private string myTag;
    private string monsterType;
    public string position;

    private Monster myMonster;
    public static Dictionary<int, int> monsterLoc = new Dictionary<int, int>();
    public static Dictionary<string, string> gorMonsterLoc = new Dictionary<string, string>();
    public static Dictionary<string, string> skralMonsterLoc = new Dictionary<string, string>();
    public static Dictionary<string, string> trollMonsterLoc = new Dictionary<string, string>();
    public static Dictionary<string, string> wardokMonsterLoc = new Dictionary<string, string>();


    public static Dictionary<string, string> monsterPositions = new Dictionary<string, string>();
    public static Dictionary<string, string> tempMonsterPositions = new Dictionary<string, string>();


    //public void move(ref Node path)
    //{
    //    moveStrat.move(ref path, this);
    //}

    //    void start()
    //{
    //    loadNeighbours();
    //}


    public static void moveAllMonstersAtSunrise()
    {
        tempMonsterPositions = monsterPositions;
        Debug.Log("Number of gors: " + BoardContents.getAllGorPositions().Count());
        move("gor");
        Debug.Log("Number of skrals: " + BoardContents.getAllSkralPositions().Count());
        move("skral");
        BoardContents.initAndGetGor(gorMonsterLoc);
        BoardContents.initAndGetGor(skralMonsterLoc);
        BoardContents.initAndGetGor(monsterPositions);
        // move("wardrak");
        // move("troll");
        // move("Wardrak");
    }

    //CURRENTLY TESTING MOVE MONSTERS WITH EACH PLAYER MOVE
    public static void move(string monsterTag)
    {
        int i = 0;
        Debug.Log("reached monster move!!!");
        //Create a dictionary storing monsters and their positions

        Dictionary<string, string> monster = new Dictionary<string, string>();
        if (monsterTag == "skral")
        {
            monster = skralMonsterLoc;
            Debug.Log("skral");
        }
        if (monsterTag == "gor")
        {
            monster = gorMonsterLoc;
            Debug.Log("gor");

        }

        //Dictionary<string, string> tempMonsterLoc = new Dictionary<string, string>();
        //tempMonsterLoc = monsterPositions;

        foreach (KeyValuePair<string, string> entry in monster)
            {
            i++;
            Debug.Log("MonsterCount: "+ monster.Count());
            Debug.Log("num of loops: " + i);
            int nextLoc;
            int currLoc = convertToInt(entry.Value);
	        if(currLoc == 0)
            {
                nextLoc = 0;
                //implement method for placing monsters on shields 
            }
            else
            {
                nextLoc = monsterLoc[currLoc];
                //if a monster already exists on the spot, we find the next available spot
                while (monsterPositions.ContainsValue(nextLoc.ToString()))
                {
                    //loop til you find spot
                    nextLoc = monsterLoc[nextLoc];
                }
            }
          
                Debug.Log(nextLoc);
                GameObject newPos = GameObject.FindGameObjectWithTag(nextLoc.ToString());
                Vector3 nex = newPos.GetComponent<BoardPosition>().getMiddle();
                GameObject monsterToMove = GameObject.FindGameObjectWithTag(entry.Key);
                monsterToMove.GetComponent<Monster>().position = nextLoc.ToString();
                monsterToMove.transform.position = nex;

            //tempMonsterPositions[entry.Key] = nextLoc.ToString();
       

            //THIS PART DOESN'T WORK!!!!
            //monsterPositions[entry.Key] = nextLoc.ToString();

            //HAD TO UNCOMMENT THE PARTS WHICH UPDATE THE MONSTER POSITIONS 
            char c = entry.Key[0];
            if (c == 's')
            {
               // BoardContents.setNewSkralPosition(entry.Key, nextLoc.ToString());
               // BoardContents.setNewMonsterPosition(entry.Key, nextLoc.ToString());

                //skralMonsterLoc[entry.Key] = nextLoc.ToString();
                //monsterPositions[entry.Key] = nextLoc.ToString();
            }
            if (c == 'g')
            {
               // BoardContents.setNewSkralPosition(entry.Key, nextLoc.ToString());
               // BoardContents.setNewMonsterPosition(entry.Key, nextLoc.ToString());

                // gorMonsterLoc[entry.Key] = nextLoc.ToString();
                // monsterPositions[entry.Key] = nextLoc.ToString();
            }
            if (c == 'w')
            {
               // wardokMonsterLoc[entry.Key] = nextLoc.ToString();
               // monsterPositions[entry.Key] = nextLoc.ToString();

            }
            if (c == 't')
            {
                //trollMonsterLoc[entry.Key] = nextLoc.ToString();
               // monsterPositions[entry.Key] = nextLoc.ToString();

            }
        }
        //monsterPositions = tempMonsterLoc;
    }

    //public static void updateMonsterPositions(Dictionary<string, string> updatedLoc)
    //{
    //    foreach (var entry in monsterPositions)
    //    {
    //        if (updatedLoc.ContainsKey(entry.Key))
    //        {
    //            monsterPositions[entry.Key] = updatedLoc[entry.Key];
    //        }
    //    }
    //}

    public static void console()
    {
        GameConsole.instance.UpdateFeedback("yo i can reach monster method");

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
        readGraphCSV();
        myMonster = new Monster();
    }



    //public static Node[] nodes = new Node[85];


    // protected constructor since this class is a singleton.
    // ie only children can call the constructor
    //protected Monster()
    //{
    //    // nodes = new Dictionary<int, int[]>();
    //    //nodes = new Node[85];
    //    loadNeighbours();
    //}

    //public void loadNeighbours()
    //{
    //    readGraphCSV();
    //}


    private void readGraphCSV()
    {
        using (var reader = new StreamReader(@"./Assets/C#/adjacencyList.txt"))
        {
            int i = 1;
            foreach(KeyValuePair<int, int> kv in monsterLoc)
            {
                Debug.Log(kv.Key + " " + kv.Value);
            }
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine().ToString().TrimEnd(Environment.NewLine.ToCharArray());
                //Debug.Log(i + " " + line);
                string[] neighbourIndices = line.Split(',');

                // int[] neighbourIndices = toIntArray(tmp);

                int currentPos = convertToInt(neighbourIndices[0]);
                //Debug.Log(currentPos);
                int nextPos = convertToInt(neighbourIndices[1]);
                //Debug.Log(nextPos);

                // have only added up to here in the csv
                //if (currentPos > 62)
                //{
                //    break;
                //}
               monsterLoc.Add(currentPos, nextPos);
                i++;
                // skip fstElem: currentPos so we don't add it as a neighbour of itself
                //addNeighboursOf(currentPos, neighbourIndices.Skip(1).ToArray()[0]);
            }
        }
    }


    //private void addNeighboursOf(int currentPos, string[] neighbours)
    //{
    //    List<int> foundNeighbours = new List<int>();

    //    foreach (string neighbour in neighbours)
    //    {
    //        foundNeighbours.Add(convertToInt(neighbour));
    //    }
    //    // this sets nodes[currentPos].neighbours to below value
    //    nodes[currentPos] = new Node(currentPos, foundNeighbours.ToArray());


    //    // for testing
    //    Console.WriteLine("neighbours of node: " + currentPos.ToString());
    //    Debug.Log("neighbours of node: " + currentPos.ToString());
    //    string neighbourString = "";
    //    foreach (int idk in nodes[currentPos])
    //    {
    //        neighbourString += idk.ToString() + ", ";
    //    }
    //    Debug.Log(neighbourString);
    //}

//helper funcctions******************************************************************
    private static int convertToInt(string prev)
    {
        int newInt;
        bool success = Int32.TryParse(prev, out newInt);
        // will this ever get executed or is error thrown right away?
        if (!success)
        {
            Console.WriteLine("StackTrace: '{0}'", Environment.StackTrace);
            print("\n --- Error converting int to string, check stackTrace.\n --- Called from convertToInt in 'masterClass.cs' script.");
            return -12345;
        }
        return newInt;
    }

    private int[] toIntArray(string[] stringArr)
    {
        int[] intArr = new int[stringArr.Length];
        for (int i = 0; i < stringArr.Length; i++)
        {
            intArr[i] = convertToInt(stringArr[i]);
        }
        return intArr;
    }
}
