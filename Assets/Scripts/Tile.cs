using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assembly_CSharp
{
    //
    public class Tile
    {
        public GameObject gameObject  { get; set; }
        public MeshRenderer Renderer { get; set; }
        public Material material { get; set; }
        public MeshFilter meshFilter { get; set; }
        public Mesh mesh { get; set; }
        private int x;
        private int y;

        public Tile(int x, int y) //i should put this into separate class 
        {
            this.x = x;
            this.y = y;
            gameObject = new GameObject($"Tile: X:{x} Y:{y}");
            gameObject.transform.SetPositionAndRotation(CreateVector3FromNode(x, y), new Quaternion(0,0,0,0));
            Renderer = gameObject.AddComponent<MeshRenderer>();
            Renderer.enabled = true;
            material = new Material(Shader.Find("Standard"));
            material.color = Color.white;
            Renderer.material = material;
            meshFilter = gameObject.AddComponent<MeshFilter>();
            mesh = new Mesh();
            mesh.vertices = CreateSquareVector3Array(new Vector3(0,0));
            mesh.triangles = ReturnHardCodedTriangles();
            mesh.uv = CreateSquareVector2Array(CreateVector3FromNode(x, y));
            meshFilter.mesh = mesh;
            gameObject.AddComponent<BoxCollider2D>();
        }
        private static Vector3 CreateVector3FromNode(int x, int y) 
        {
            return new Vector3(x,y);
        }

        private static Vector3[] CreateSquareVector3Array(Vector3 initialVector3)
        {
            return new Vector3[]
            {
                new Vector3(initialVector3.x + 0.5f, initialVector3.y + 0.5f),
                new Vector3(initialVector3.x + 0.5f, initialVector3.y - 0.5f),
                new Vector3(initialVector3.x - 0.5f, initialVector3.y + 0.5f),
                new Vector3(initialVector3.x - 0.5f, initialVector3.y - 0.5f)
            };
        }

        private static int[] ReturnHardCodedTriangles()
        {
            return new int[6]
            {
                // lower left triangle
                0, 2, 1,
                // upper right triangle
                2, 3, 1
            };
        }
        private static Vector2[] CreateSquareVector2Array(Vector3 initialVector3)
        {
            return new Vector2[4]
            {
                  new Vector2(initialVector3.x + 0.5f, initialVector3.y + 0.5f),
                  new Vector2(initialVector3.x + 0.5f, initialVector3.y - 0.5f),
                  new Vector2(initialVector3.x - 0.5f, initialVector3.y + 0.5f),
                  new Vector2(initialVector3.x - 0.5f, initialVector3.y - 0.5f)
            };
        }

    }
}
