// This project is being made while following this tutorial: https://unity3d.com/learn/tutorials/projects/procedural-cave-generation-tutorial/cellular-automata?playlist=17153

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class mapGeneration : MonoBehaviour
{
    public int height;
    public int width;

    public bool useRandomSeed;
    public string seed;

    [Range(0,100)]
    public int fillPercent;

    int[,] map;
 
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        map = new int[width, height];
        RandomlyFillMap();
    }

    void RandomlyFillMap()
    {
        if(useRandomSeed)
        {
            seed = Time.time.ToString();  
        }

        System.Random randomNumberGenerator = new System.Random(seed.GetHashCode());

        for(int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    map[x, y] = 1;
                }
                else
                {
                    map[x, y] = (randomNumberGenerator.Next(0, 100) < fillPercent) ? 1 : 0;
                }

            }
        }
    }

    void SmoothMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

            }
        }
    }

    int GetSurroundingWallCount(int gridX, int gridY)
    {
        wallCount = 0;
        for (int neighboringX = gridX - 1; neighboringX <= gridX + 1; neighboringX++)
        {
            for (int neighboringY = gridY - 1; neighboringY <= gridY + 1; neighboringY++)
            {





                //AT 14:55 https://www.youtube.com/watch?time_continue=8&v=v7yyZZjF1z4




            }
        }
    }

    void OnDrawGizmos()
    {
        if(map != null)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Gizmos.color = (map[x, y] == 1) ? Color.black : Color.white;
                    Vector3 pos = new Vector3(-width / 2 + x + .5f, 0, -height / 2 + y + .5f);
                    Gizmos.DrawCube(pos, Vector3.one);
                }
            }
        }
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
