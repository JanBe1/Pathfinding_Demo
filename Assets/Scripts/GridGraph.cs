using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;

namespace Assets.Scripts
{
    public class GridGraph<T>
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int NodeCount { get; private set; } = 0;
        public int EdgeCount { get; private set; } = 0;
        public Dictionary<Node<T>, List<Node<T>>> AdjacencyList { get; private set; }
        public List<Node<T>> Nodes { get; private set; }
        public GridGraph(int width, int height, bool connected = true)
        {
            Width = width;
            Height = height;
            Nodes = new List<Node<T>>();
            AdjacencyList = new Dictionary<Node<T>, List<Node<T>>>();
            for(int i = 0; i < Height; i++)
            {
                for(int j = 0; j < Width; j++)
                {
                    Nodes.Add(item: new Node<T>(i, j));
                    NodeCount++;
                }
            }
            foreach(var node in Nodes)
            {
                AdjacencyList.Add(node, new List<Node<T>>());
            }
            if(connected)
                ConnectAll();
        }
        public void AddConnection(Node<T> one, Node<T> two) 
        {
            AdjacencyList[one].Add(two);
            AdjacencyList[two].Add(one);
            EdgeCount++;
        }

        public void ConnectAll() 
        {
            int x, y;
            foreach(Node<T> node in Nodes)
            {
                x = node.X;
                y = node.Y;

                //todo move to a function lol
                if(AdjacencyList.Keys.Any(n => n.X == x - 1 && n.Y == y))
                {
                    AdjacencyList[node].Add(Nodes.Find(n => n.X == x - 1 && n.Y == y));
                    EdgeCount++;
                }

                if (AdjacencyList.Keys.Any(n => n.X == x + 1 && n.Y == y))
                {
                    AdjacencyList[node].Add(Nodes.Find(n => n.X == x + 1 && n.Y == y));
                    EdgeCount++;
                }

                if (AdjacencyList.Keys.Any(n => n.X == x && n.Y == y - 1))
                {
                    AdjacencyList[node].Add(Nodes.Find(n => n.X == x && n.Y == y - 1));
                    EdgeCount++;
                }

                if (AdjacencyList.Keys.Any(n => n.X == x && n.Y == y + 1))
                {
                    AdjacencyList[node].Add(Nodes.Find(n => n.X == x && n.Y == y + 1));
                    EdgeCount++;
                }

                if (AdjacencyList.Keys.Any(n => n.X == x+1 && n.Y == y + 1))
                {
                    AdjacencyList[node].Add(Nodes.Find(n => n.X == x+1 && n.Y == y + 1));
                    EdgeCount++;
                }
                if (AdjacencyList.Keys.Any(n => n.X == x-1 && n.Y == y + 1))
                {
                    AdjacencyList[node].Add(Nodes.Find(n => n.X == x-1 && n.Y == y + 1));
                    EdgeCount++;
                }
                if (AdjacencyList.Keys.Any(n => n.X == x+1 && n.Y == y - 1))
                { 
                    AdjacencyList[node].Add(Nodes.Find(n => n.X == x+1 && n.Y == y - 1));
                    EdgeCount++;
                }
                if (AdjacencyList.Keys.Any(n => n.X == x-1 && n.Y == y - 1))
                {
                    AdjacencyList[node].Add(Nodes.Find(n => n.X == x-1 && n.Y == y - 1));
                    EdgeCount++;
                }
            }
        }
        public void GetNeighbours(Node<T> node)
        {
            foreach(var neighbour in AdjacencyList[node])
            {
                Debug.Log(neighbour);
            }
        }
        public void GetNeighbours(int x, int y)
        {
            Node<T> found = Nodes.Find(n => n.X == x && n.Y == y);
            foreach (var neighbour in AdjacencyList[found])
            {
                Debug.Log($"Typing all the neighbours for node {x} {y}");
                Debug.Log($"{neighbour.X}, {neighbour.Y}");
            }
        }
        public Node<T> GetNode(int x, int y)
        {
            return Nodes.Find(n=>n.X == x && n.Y == y);
        }

        public void RemoveConnection(int x, int y)
        {
            var one = Nodes.Find(n => n.X == x && n.Y == y);
            AdjacencyList.Remove(one);
            foreach(var nodeList in AdjacencyList.Values)
            {
                nodeList.Remove(nodeList.Find(n => n.X == x && n.Y == y));
            }
        }
    }
}
