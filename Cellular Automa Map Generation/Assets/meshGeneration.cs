// Code written using following tutorial: https://www.youtube.com/watch?v=yOgIncKp0BE
// and https://www.youtube.com/watch?v=2gIxh8CX3Hk

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGeneration : MonoBehaviour
{

    public SquareGrid squareGrid;
    List<Vector3> vertices;
    List<int> triangles;

    public void GenerateMesh(int[,] map, float squareSize)
    {
        vertices = new List<Vector3>();
        triangles = new List<int>();

        squareGrid = new SquareGrid(map, squareSize);

        for (int x = 0; x < squareGrid.squares.GetLength(0); x++)
        {
            for (int y = 0; y < squareGrid.squares.GetLength(1); y++)
            {
                TriangulateSquare(squareGrid.squares[x, y]);
            }
        }

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
    }
    void TriangulateSquare(Square square)
    {
        switch (square.config)
        {   
            case 0:
                break;

            case 1:
                MeshFromPoints(square.centerBot, square.botLeft, square.centerLeft);
                break;
            case 2:
                MeshFromPoints(square.centerRight, square.botRight, square.centerBot);
                break;
            case 4:
                MeshFromPoints(square.centerTop, square.topRight, square.centerRight);
                break;
            case 8:
                MeshFromPoints(square.topRight, square.centerTop, square.centerLeft);
                break;


            case 3:
                MeshFromPoints(square.centerRight, square.botRight, square.botLeft, square.centerLeft);
                break;
            case 6:
                MeshFromPoints(square.centerTop, square.topRight, square.botRight, square.centerBot);
                break;
            case 9:
                MeshFromPoints(square.topLeft, square.centerTop, square.centerBot, square.botLeft);
                break;
            case 12:
                MeshFromPoints(square.topLeft, square.topRight, square.centerRight, square.centerLeft);
                break;


            case 5:
                MeshFromPoints(square.centerTop, square.topRight, square.centerRight, square.centerBot, square.botLeft, square.centerLeft);
                break;
            case 10:
                MeshFromPoints(square.topLeft, square.centerTop, square.centerRight, square.botRight, square.centerBot, square.centerLeft);
                break;


            case 7:
                MeshFromPoints(square.centerTop, square.topRight, square.botRight, square.botLeft, square.centerLeft);
                break;
            case 11:
                MeshFromPoints(square.topLeft, square.centerTop, square.centerRight, square.botRight, square.botLeft);
                break;
            case 13:
                MeshFromPoints(square.topRight, square.centerRight, square.centerBot, square.botLeft, square.topLeft);
                break;
            case 14:
                MeshFromPoints(square.topRight, square.botRight, square.centerBot, square.centerLeft, square.topLeft);
                break;


            case 15:
                MeshFromPoints(square.topRight, square.botRight, square.botLeft, square.topLeft);
                break;

        }
    }

    void MeshFromPoints(params Node[] points)
    {
        AssignVertices(points);

        if (points.Length >= 3)
        {
            CreateTriangle(points[0], points[1], points[2]);
        }
        if (points.Length >= 4)
        {
            CreateTriangle(points[0], points[2], points[3]);
        }
        if (points.Length >= 5)
        {
            CreateTriangle(points[0], points[3], points[4]);
        }
        if (points.Length >= 6)
        {
            CreateTriangle(points[0], points[4], points[5]);
        }
    }

    void AssignVertices(Node[] points)
    {
        for (int n = 0; n < points.Length; n++)
        {
            if (points[n].vertIndex == -1)
            {
                points[n].vertIndex = vertices.Count;
                vertices.Add(points[n].position);
            }
        }
    }

    void CreateTriangle(Node a, Node b, Node c)
    {
        triangles.Add(a.vertIndex);
        triangles.Add(b.vertIndex);
        triangles.Add(c.vertIndex);
    }

    public class SquareGrid
    {
        public Square[,] squares;

        public SquareGrid(int[,] map, float squareSize)
        {
            int nodeCountX = map.GetLength(0);
            int nodeCountY = map.GetLength(1);

            float mapWidth = nodeCountX * squareSize;
            float mapHeight = nodeCountY * squareSize;

            ControlNode[,] controlNodes = new ControlNode[nodeCountX, nodeCountY];

            for (int x = 0; x < nodeCountX; x++)
            {
                for (int y = 0; y < nodeCountY; y++)
                {
                    Vector3 pos = new Vector3(-mapWidth / 2 + x * squareSize + squareSize / 2, 0, -mapHeight / 2 + y * squareSize + squareSize / 2);
                    controlNodes[x, y] = new ControlNode(pos, map[x, y] == 1, squareSize);
                }
            } 

            squares = new Square[nodeCountX - 1, nodeCountY - 1];

            for (int x = 0; x < nodeCountX - 1; x++)
            {
                for (int y = 0; y < nodeCountY - 1; y++)
                {
                    squares[x, y] = new Square(controlNodes[x, y + 1], controlNodes[x + 1, y + 1], controlNodes[x + 1, y], controlNodes[x, y]);
                }
            }
        }

    }

    public class Square
    {
        public ControlNode topLeft, topRight, botRight, botLeft;
        public Node centerTop, centerBot, centerLeft, centerRight;
        public int config;

        public Square(ControlNode _topLeft, ControlNode _topRight, ControlNode _botRight, ControlNode _botLeft)
        {
            topLeft = _topLeft;
            topRight = _topRight;
            botLeft = _botLeft;
            botRight = _botRight;

            centerTop = topLeft.right;
            centerBot = botLeft.right;
            centerLeft = botLeft.above;
            centerRight = botRight.above;

            if (topLeft.active)
            {
                config += 8;
            }
            if (topRight.active)
            {
                config += 4;
            }
            if (botRight.active)
            {
                config += 2;
            }
            if (botLeft.active)
            {
                config += 1;
            }
        }
    }

    public class ControlNode : Node
    {
        public bool active;
        public Node above, right;

        public ControlNode(Vector3 _pos, bool _active, float squareSize) : base(_pos)
        {
            active = _active;
            above = new Node(position + Vector3.forward * squareSize / 2f);
            right = new Node(position + Vector3.right * squareSize / 2f);
        }

    }


    public class Node
    {
        public Vector3 position;
        public int vertIndex = -1;

        public Node(Vector3 _pos)
        {
            position = _pos;
        }
    }



    private void OnDrawGizmos()
    {


        //if (squareGrid != null)
        //{
        //    for (int x = 0; x < squareGrid.squares.GetLength(0); x++)
        //    {
        //        for (int y = 0; y < squareGrid.squares.GetLength(1); y++)
        //        {
        //            Gizmos.color = (squareGrid.squares[x, y].topLeft.active) ? Color.black : Color.white;
        //            Gizmos.DrawCube(squareGrid.squares[x, y].topLeft.position, Vector3.one * .4f);

        //            Gizmos.color = (squareGrid.squares[x, y].topRight.active) ? Color.black : Color.white;
        //            Gizmos.DrawCube(squareGrid.squares[x, y].topRight.position, Vector3.one * .4f);

        //            Gizmos.color = (squareGrid.squares[x, y].botLeft.active) ? Color.black : Color.white;
        //            Gizmos.DrawCube(squareGrid.squares[x, y].botLeft.position, Vector3.one * .4f);

        //            Gizmos.color = (squareGrid.squares[x, y].botRight.active) ? Color.black : Color.white;
        //            Gizmos.DrawCube(squareGrid.squares[x, y].botRight.position, Vector3.one * .4f);


        //            Gizmos.color = Color.grey;
        //            Gizmos.DrawCube(squareGrid.squares[x, y].centerBot.position, Vector3.one * .15f);
        //            Gizmos.DrawCube(squareGrid.squares[x, y].centerTop.position, Vector3.one * .15f);
        //            Gizmos.DrawCube(squareGrid.squares[x, y].centerLeft.position, Vector3.one * .15f);
        //            Gizmos.DrawCube(squareGrid.squares[x, y].centerRight.position, Vector3.one * .15f);


        //        }
        //    }
        //}
    }

}
