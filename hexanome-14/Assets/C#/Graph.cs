﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class Graph : MonoBehaviour, IEnumerable<Node>
{
    //TODO: --make a getAllPaths(distance d) function so we can show all possible
    // moves from the current position upon turn change
    // -- test the bfs shit, maybe change to int[]

    // if a monster is on pos: nodes[i][0].
    // then it moves to   pos: nodes[i][1].
    // private Node[] nodes;
    // private Dictionary<int, int[]> nodes;
    private Node[] nodes;
    private int numNodes;


    // protected constructor since this class is a singleton.
    // ie only children can call the constructor
    void Start()
    {
        // nodes = new Dictionary<int, int[]>();
        nodes = new Node[85];
        loadNeighbours();
    }

    public int getDistance(string src, string dest)
    {
        int srcIndex = convertToInt(src);
        int destIndex = convertToInt(dest);

        // destNode has its attribute: prev set correctly now
        // Node destNode = ref bfs(nodes[srcIndex], nodes[destIndex]);
        Node destNode = new Node(destIndex, new int[] {0,1,2});
        bfs(nodes[srcIndex], nodes[destIndex], ref destNode);

        return calculateDistance(ref destNode, destIndex);
    }

    public Dictionary<string, int> allDistancesFrom(string currPos)
    {
        Dictionary<string, int> distances = new Dictionary<string, int>();
        foreach(Node node in nodes)
        {
            string otherPos = node.getIndex().ToString();
            distances.Add(otherPos, getDistance(currPos, otherPos));
        }
        return distances;
    }

    public Dictionary<string, int> getWithinDistance(string currPos, int maxDist)
    {
        Dictionary<string, int> withinDist = new Dictionary<string, int>();

        foreach(KeyValuePair<string, int> distTo in allDistancesFrom(currPos))
        {
            if (distTo.Value <= maxDist)
                withinDist.Add(distTo.Key, distTo.Value);
        }
        return withinDist;
    }


    // these allow IEnum fxns allow us to iterate over all nodes
    // a foreach loop
    public IEnumerator<Node> GetEnumerator()
    {
        for(int i = 0; i < nodes.Length; i++)
            yield return nodes[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    private void addNeighboursOf(int currentPos, string[] neighbours)
    {
        List<int> foundNeighbours = new List<int>();

        foreach (string neighbour in neighbours)
        {
            foundNeighbours.Add(convertToInt(neighbour));
        }
        // this sets nodes[currentPos].neighbours to below value
        nodes[currentPos] = new Node(currentPos, foundNeighbours.ToArray());


        // for testing
        // Debug.Log("neighbours of node: " + currentPos.ToString());
        string neighbourString = "";
        foreach(int idk in nodes[currentPos])
        {
            neighbourString += idk.ToString() + ", ";
        }
        // Debug.Log(neighbourString);
    }



    private int calculateDistance(ref Node current, int destIndex)
    {
        int dist = 0;
        while (current.getIndex() != destIndex)
        {
            current = ref current.getPrev();
            dist++;
        }

        return dist;
    }

    // maybe should change the bfs to store a list of int[]'s indicating the path
    // instead of relying on ref variables.
    // void since we use pathNode
    private void bfs(Node src, Node dest, ref Node pathNode)
    {
        Queue queue = new Queue();
        // src.setPrev(null);
        queue.Enqueue(src);

        HashSet<int> visited = new HashSet<int>();
        while(queue.Count != 0)
        {
            Node node = (Node) queue.Dequeue();
            int nodeIndex = node.getIndex();

            if (visited.Contains(nodeIndex)) { continue; }

            // if notLooking for castle zero then don't consider as neighbour??
            // can we go thru the castle space if convenient?
            if (nodeIndex == dest.getIndex())
            {
                pathNode.setPrev(ref node);
                return;
            }
            visited.Add(nodeIndex);

            foreach(int neighbour in node.getNeighbours())
            {
                if (visited.Contains(neighbour)) { continue; }

                nodes[neighbour].setPrev(ref node);
                queue.Enqueue(neighbour);
            }
        }
        return;
        // return ref new Node(0, new int[] {-1, -1, -1});
    }


    private void loadNeighbours()
    {
        readGraphCSV();
    }


    private void readGraphCSV()
    {
        numNodes = 0;
        using(var reader = new StreamReader(@"./Assets/CSV/adjacencyList.txt"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine().ToString().TrimEnd( Environment.NewLine.ToCharArray());
                string[] neighbourIndices = line.Split(',');

                // int[] neighbourIndices = toIntArray(tmp);

                int currentPos = convertToInt(neighbourIndices[0]);

                // skip fstElem: currentPos so we don't add it as a neighbour of itself
                addNeighboursOf(currentPos, neighbourIndices.Skip(1).ToArray());
                numNodes++;
            }
        }
    }


    public int getNumBoardPos()
    {
        return numNodes;
    }


// ------ some helper functions -------

    private int convertToInt(string prev)
    {
        int newInt;
        bool success = Int32.TryParse(prev, out newInt);
        // will this ever get executed or is error thrown right away?
        if(!success)
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
