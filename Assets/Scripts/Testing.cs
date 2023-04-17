using Assembly_CSharp;
using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Xsl;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class Testing : MonoBehaviour
{
    GameObject selectedObject;
    GameObject removedNode;
    GridGraph<int> graph;
    Node<int> start;
    Node<int> end;
    KeyCode lastPressed;
    // Start is called before the first frame update
    private void Start()
    {
        graph = new GridGraph<int>(10,10);
    }
    private void Update()
    {
        if (start == null)
        {
            SetStartingPoint();
        }
        if(start!= null && end == null)
        {
           SetFinishPoint();
        }
        if(start != null && end != null)
        {
            BreadthFirstSearch<int> bfs = new BreadthFirstSearch<int>(graph, start);
            bfs.Path(end);
        }
        RightClickRemoveNode();
    }

    private void SetStartingPoint()
    {
        DetectClickOnGridObject(KeyCode.Mouse0);
        if (selectedObject != null)
        {
            start = graph.GetNode((int)selectedObject.transform.transform.position.x, (int)selectedObject.transform.transform.position.y);
            start.ChangeTileColor(Color.red);
        }

    }
    private void SetFinishPoint()
    {
        var lastSelected = selectedObject;
        DetectClickOnGridObject(KeyCode.Mouse0);
        if (start != null)
        {
            if (selectedObject != null && lastSelected != selectedObject)
            {
                end = graph.GetNode((int)selectedObject.transform.transform.position.x, (int)selectedObject.transform.transform.position.y);
                end.ChangeTileColor(Color.blue);
            }
        }
    }
    private void DetectClickOnGridObject(KeyCode code)
    {
        if (Input.GetKeyDown(code))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0);
            if (hitData && Input.GetKeyDown(code) && code == KeyCode.Mouse0)
            {
                selectedObject = hitData.transform.gameObject;
            }
            if (hitData && Input.GetKeyDown(code) && code == KeyCode.Mouse1)
            {
                removedNode = hitData.transform.gameObject;
            }
        }
    }

    private void RightClickRemoveNode()
    {
        DetectClickOnGridObject(KeyCode.Mouse1);
        if(removedNode != null)
        {
            graph.GetNode((int)removedNode.transform.position.x, (int)removedNode.transform.position.y).ChangeTileColor(Color.yellow);
            graph.RemoveConnection((int)removedNode.transform.position.x, (int)removedNode.transform.position.y);
        }

    }
    //private void TransformGameObjectCoordinatesToNodeCoords(out int x, out int y)
    //{
    //    x = (int)selectedObject.transform.transform.position.x;
    //    y = (int)selectedObject.transform.transform.position.y;
    //}
}
