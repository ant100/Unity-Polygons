using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class meshGenerator : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        mesh.name = "Procedural Quad";

        GetComponent<MeshFilter>().mesh = mesh;

        // createShape();
        // updateMesh();

        // the vertices
        /*List<Vector3> points = new List<Vector3>()
        {
            new Vector3(-1,  1),
            new Vector3( 1,  1),
            new Vector3(-1, -1),
            new Vector3( 1, -1)
        };*/
        vertices = new Vector3[]
       {
            new Vector3(-1, 1, 0),
            new Vector3( 1, 1, 0),
            new Vector3(-1,-1, 0),
            new Vector3( 1,-1, 0)
       };

        // define the triangles
        int[] triIndices = new int[]
        {
            2,0,1,
            2,1,3
        };

        //mesh.SetVertices(points); // this accepts a list
        mesh.vertices = vertices;
        mesh.triangles = triIndices;

        // GetComponent<MeshFilter>().mesh = mesh;
        mesh.RecalculateNormals();
    }

    void createShape()
    {
        vertices = new Vector3[]
        {
            new Vector3(0,0,0),
            new Vector3(0,0,1),
            new Vector3(1,0,0),
            new Vector3(1,0,1)
        };

        triangles = new int[]
        {
            0, 1, 2,
            1, 3, 2
        };
    }

    void updateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
}
