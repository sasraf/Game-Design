// Code written using following tutorial: https://www.youtube.com/watch?v=yOgIncKp0BE


// 11:50
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshGeneration : MonoBehaviour
{
    public class Node
    {
        public Vector3 position;
        public int vertIndex = -1;

        public Node(Vector3 _pos)
        {
            position = _pos;
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

    public class Square
    {
        public ControlNode topLeft, topRight, botRight, botLeft;
        public Node centerTop, centerBot, centerLeft, centerRight;

        public Square(ControlNode _topLeft, ControlNode _topRight, ControlNode _botLeft, ControlNode _botRight)
        {
            topLeft = _topLeft;
            topRight = _topRight;
            botLeft = _botLeft;
            botRight = _botRight;

            centerTop = topLeft.right;
            centerBot = botLeft.right;
            centerLeft = botLeft.above;
            centerRight = botRight.above;
        }
    }

    public class SquareGrid
    {
        public Square[,] squares;

        public SquareGrid(int[,] map, float squareSize)
        {

        }
    }
}
