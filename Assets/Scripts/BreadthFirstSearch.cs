using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assembly_CSharp
{
    public class BreadthFirstSearch<T>
    {
        private bool[] marked;

        private Dictionary<Node<T>,Node<T>> edgeTo;
        private Node<T> s;
        private GridGraph<T> G;

        public BreadthFirstSearch(GridGraph<T> G, Node<T> s)
        {
            this.G = G;
            marked = new bool[G.NodeCount];
            edgeTo = new Dictionary<Node<T>, Node<T>>();
            this.s = s;
            Bfs(G, s);

        }

        private void Bfs(GridGraph<T> g, Node<T> s)
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            marked[g.Nodes.IndexOf(s)] = true;
            queue.Enqueue(s);
            while (queue.Any())
            {
                Node<T> node = queue.Dequeue();
                foreach (var secondNode in g.AdjacencyList[node])
                    if (!marked[g.Nodes.IndexOf(secondNode)])
                    {
                        edgeTo.Add(secondNode, node);
                        secondNode.ChangeTileColor(Color.cyan);
                        marked[g.Nodes.IndexOf(secondNode)] = true;
                        queue.Enqueue(secondNode);
                    }
            }
        }
        private bool hasPathTo(Node<T> end)
        {
            return marked[G.Nodes.IndexOf(end)];
        }
        public /*IEnumerable<Node<T>>*/ void Path(Node<T> end)
        {
            if(!hasPathTo(end))
            {
                return; //null;
            }
            Stack<Node<T>> stack = new Stack<Node<T>>();
            for(Node<T> x = end; x != s; x = edgeTo[x])
            {
                stack.Push(x);
                x.ChangeTileColor(Color.black);
            }
            stack.Push(s);
            s.ChangeTileColor(Color.black);
            //return stack;

        }
    }
}
