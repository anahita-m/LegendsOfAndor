using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class middlePositions
{
    public static Dictionary<string, Vector3> middles = new Dictionary<string, Vector3>();

    public middlePositions()
    {
        fillMiddles();
    }

    private void fillMiddles()
    {
        using(var reader = new StreamReader(@"./Assets/CSV/middlePositions.csv"))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine().ToString().TrimEnd( Environment.NewLine.ToCharArray());

                string[] neighbourIndices = line.Split(',');

                // int[] neighbourIndices = toIntArray(tmp);

                // int currentPos = convertToInt(neighbourIndices[0]);
                string currentPosTag = neighbourIndices[0];

                // skip fstElem: currentPos so we don't add it as a neighbour of itself
                addMiddle(currentPosTag, neighbourIndices.Skip(1).ToArray());
            }
        }
    }

    private void addMiddle(string posTag, string[] coordinates)
    {
        float[] coords = new float[3];
        for (int i = 0; i < 3; i++)
        {
            // try{
            coords[i] = float.Parse(coordinates[i]);
        }
        middles[posTag] = new Vector3(coords[0], coords[1], coords[2]);
    }
}
