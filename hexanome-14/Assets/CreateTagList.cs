using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CreateTagList : MonoBehaviour
{

    // private dynamic getAllTags()
    private string[] getAllTags()
    {
        string[] otherTags = {
            "Master",
        };
        string[] playerTags = {
            "First",
            "Second",
            "Third",
            "Fourth",
            "Fifth",
            "Sixth",
        };
        string[] heroTags = {
            "Hero-First",
            "Hero-Second",
            "Hero-Third",
            "Hero-Fourth",
            "Hero-Fifth",
            "Hero-Sixth",
        };
        string[] heroSphereTags = {
            "sphere_childOf_First",
            "sphere_childOf_Second",
            "sphere_childOf_Third",
            "sphere_childOf_Fourth",
            "sphere_childOf_Fifth",
            "sphere_childOf_Sixth",
        };
        string[] boardPositionTags = {
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84",
        };

        int numTags = otherTags.Length + playerTags.Length + heroTags.Length + heroSphereTags.Length + boardPositionTags.Length;
        string [] allTags = new string[numTags];
        int ct = 0;
        int currLen = otherTags.Length;
        for (int i = 0;  i < allTags.Length; i++)
        {
            if (i < currLen)
            {
                allTags[i] = otherTags[ct++];
                if (ct == otherTags.Length)
                {
                    currLen += playerTags.Length;
                    ct = 0;
                }
            } else if ( i < currLen)
            {
                allTags[i] = playerTags[ct++];
                if (ct == playerTags.Length)
                {
                    currLen += heroTags.Length;
                    ct = 0;
                }
            } else if (i < currLen)
            {
                allTags[i] = heroTags[ct++];
                if (ct == heroTags.Length)
                {
                    currLen += heroSphereTags.Length;
                    ct = 0;
                }
            } else if (i < currLen)
            {
                allTags[i] = heroSphereTags[ct++];
                if (ct == heroSphereTags.Length)
                {
                    currLen += boardPositionTags.Length;
                    ct = 0;
                }
            } else if (i < currLen)
            {
                allTags[i] = boardPositionTags[ct++];
                // ct = (ct == boardPositionTags.Length) ? 0 : ct;
            }
        }
        // var tags = theTags.Union(heroTags).Union(heroSphereTags).Union(boardPositionTags);

        return allTags;
    }


    void Start()
    {
    // https://answers.unity.com/questions/33597/is-it-possible-to-create-a-tag-programmatically.html
    // Open tag manager
    SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
    SerializedProperty tagsProp = tagManager.FindProperty("tags");

    foreach(string tag in getAllTags())
    {

        print(tag);
        // First check if it is not already present
        bool found = false;
        for (int i = 0; i < tagsProp.arraySize; i++)
        {
            SerializedProperty t = tagsProp.GetArrayElementAtIndex(i);
            if (t.stringValue.Equals(tag)) { found = true; break; }
        }

        // if not found, add it
        if (!found)
        {
            tagsProp.InsertArrayElementAtIndex(0);
            SerializedProperty n = tagsProp.GetArrayElementAtIndex(0);
            n.stringValue = tag;
        }

    }

    tagManager.ApplyModifiedProperties();
    }
}
