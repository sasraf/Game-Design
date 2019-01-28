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

    // Update is every frame
    private void Update()
    {
        // Makes new map on mouse click
        if(Input.GetMouseButtonDown(0))
        {
            GenerateMap();
        }
    }

    // Generates the map then smooths the map
    void GenerateMap()
    {
        // Creates new empty map
        map = new int[width, height];

        // Randomly fills map 
        RandomlyFillMap();

        // Smooths the map i times
        for (int i = 0; i < 5; i++)
        {
            SmoothMap();
        }
    }

    // Randomly fills map
    void RandomlyFillMap()
    {
        // If randomseed is true, then make a random seed
        if(useRandomSeed)
        {
            seed = Time.time.ToString();  
        }

        // Creates new Random Number Generator
        System.Random randomNumberGenerator = new System.Random(seed.GetHashCode());

        // Iterates through all tiles in map
        for(int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // If tiles are on border of map, make a wall
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    map[x, y] = 1;
                }
                // If tiles aren't on the border then randomly fill tile
                else
                {
                    // If the randomly selected number is less than the fill percent, make a wall
                    // otherwise make the tiile empty.
                    map[x, y] = (randomNumberGenerator.Next(0, 100) < fillPercent) ? 1 : 0;
                }

            }
        }
    }

    // Smooths map to create cave shapes
    void SmoothMap()
    {
        // Iterates through every tile in map
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Gets a count of the immediate neighboring walls
                int nearbyWalls = GetSurroundingWallCount(x, y);

                // If there are more than 4 walls nearby, make the tile a
                // wall, otherwise make it an empty tile.
                if (nearbyWalls > 4)
                {
                    map[x, y] = 1;
                }
                else if (nearbyWalls < 4)
                {
                    map[x, y] = 0;
                }
            }
        }
    }

    // Returns a count of neighboring walls
    int GetSurroundingWallCount(int gridX, int gridY)
    {
        // Initialize wallCount
        int wallCount = 0;

        // Iterate through neighboring tiles: one tile on each side
        for (int neighboringX = gridX - 1; neighboringX <= gridX + 1; neighboringX++)
        {
            for (int neighboringY = gridY - 1; neighboringY <= gridY + 1; neighboringY++)
            {
                // If the tile isn't on the border and isn't itself then add 1 or 0 to the wall count depending
                // on whether the tile is a wall or empty tile. If the tile is on the border, then add 1 to wallCount.
                if (neighboringX >= 0 && neighboringY >= 0 && neighboringX < width && neighboringY < height)
                { 
                    if (neighboringX != gridX || neighboringY != gridY)
                    {
                        wallCount += map[neighboringX, neighboringY];
                    }
                }
                else
                {
                    wallCount++;
                }

            }
        }
        return wallCount;
    }

    // Draws tiles
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
}
