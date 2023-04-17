# Pathfinding_Demo
Created with Unity. Educational project to play around with graphs and pathfinding algorithms. In active development. Might add raycasting later and make functional games based on it.

Made in Unity 2019.4.31f1. 
Based on Robert's Sedgewick algorithms book, I wanted to create 2D grid map to experiment on it. 
Created GridGraph class that uses Node<T> object with (x,y) coordinates and T value attached. 
With this graph you can use BreadthFirstSearch class which allows you to find the shortest path from starting node to ending node. 
Mouse click event is done by raycasting a light into 2D object, so it gets selected and based on it's coordinates it selects the starting node. 
Second click determines the end node.
Right click adds walls = entirely disconnects nodes from the graph = removes the node from all adjacentcy lists.  
BreadthFirstSeach object keeps all paths from each node to eachother.
Method PathTo(endNode) returns the path from starting node to finish. 
Each node has MeshGrid added to it, created with Vector3 offset to each other. Renderer uses Unity Standard shader. 
There is no need to import additional Unity Packages. 

This small project took around a week to make and will probably be still developed. 
