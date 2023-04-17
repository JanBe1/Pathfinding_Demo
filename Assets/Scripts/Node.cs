using Assembly_CSharp;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Assets.Scripts
{
    public class Node<T>
    {

        public int X { get; private set; }
        public int Y { get; private set; }
        public T Value { get; set; }
        public Tile Tile { get; set; }
        public Node(int x, int y)
        {
            X = x;
            Y = y;
            Value = default(T);
            Tile = new Tile(x,y);
        }
        public Node(int x, int y, T value)
        {
            X = x;
            Y = y;
            Value = value;
            Tile = new Tile(x, y);
        }

        public void ChangeTileColor(Color color)
        {
            Tile.material.SetColor("_Color", color);
        }
    }
}