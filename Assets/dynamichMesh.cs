using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class dynamichMesh : MonoBehaviour
{
    private Mesh mesh;
    private List<Vector3> points;
    private int[] triangles;
    public int n = 3;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        mesh.name = "Procedural Polygon";
        GetComponent<MeshFilter>().mesh = mesh;

        // Initial mesh is just a regular triangle
        createShape(n);
        updateMesh();
    }

    // Update is called once per frame
    void Update()
    {
        // get user input
        if(Input.GetKeyDown("up"))
        {
            n++;
            createShape(n);
            updateMesh();
        }
        else if(Input.GetKeyDown("down"))
        {
            if(n > 3)
            {
                n--;
                createShape(n);
                updateMesh();
            }
            else
            {
                Debug.Log("The minimum is 3!");
            }
        }       
    }

    void createShape(int n)
    {
        createVertex(n);
        /*foreach(var point in points)
        {
            Debug.Log(point);
        }*/
        drawTriangles(n);
    }

    void createVertex(int n)
    {
        float angle = (3.141592f * (360f / n)) / 180f;
        points = new List<Vector3>();
        Vector3 tmp = new Vector3(1, 0);

        // asign vectors
        points.Add(new Vector3(0, 0)); // blue
        points.Add(tmp); // red

        for (int i = 0; i < n - 1; i++)
        {
            tmp = new Vector3(tmp.x * Mathf.Cos(angle) - tmp.y * Mathf.Sin(angle), tmp.x * Mathf.Sin(angle) + tmp.y * Mathf.Cos(angle));
            points.Add(tmp); // green
        }

        // same in new z space
        /*tmp = new Vector3(1, 0, 1);
        points.Add(new Vector3(0, 0, 1)); // blue
        points.Add(tmp); // red

        for (int i = 0; i < n - 1; i++)
        {
            tmp = new Vector3(tmp.x * Mathf.Cos(angle) - tmp.y * Mathf.Sin(angle), tmp.x * Mathf.Sin(angle) + tmp.y * Mathf.Cos(angle), 1);
            points.Add(tmp); // green
        }*/

    }

    void drawTriangles(int n)
    {
        int triangle_size = (n * 2) + (n * 4);
        int tria_num = 0;
        //int start = n * 3;
        //int start2 = n * 6;
        triangles = new int[triangle_size];

        //Debug.Log(triangle_size);

        for (int j = 0; j < n * 3; j++)
        {
            if (j % 3 == 0)
            {
                triangles[j] = 0;
                tria_num++;
            }
            else if ((j - 1) % 3 == 0)
            {
                if (tria_num == n)
                {
                    triangles[j] = 1;
                }
                else
                {
                    triangles[j] = tria_num + 1;
                }
            }
            else
            {
                if (tria_num == n)
                {
                    triangles[j] = n;
                }
                else
                {
                    triangles[j] = tria_num;
                }
            }

        }

        /*for (int k = start; k < triangle_size - (n*2); k++)
        {
            if (k % 3 == 0)
            {
                triangles[k] = n+1;
                tria_num++;
            }
            else if ((k - 1) % 3 == 0)
            {
                if (tria_num == n)
                {
                    triangles[k] = n+1;
                }
                else
                {
                    triangles[k] = tria_num + 1;
                }
            }
            else
            {
                if (tria_num == n*2)
                {
                    triangles[k] = n*2;
                }
                else
                {
                    triangles[k] = tria_num+1;
                }
            }

        }

        for (int m = start2; m < triangle_size; m++)
        {

        }*/
    }

    void updateMesh()
    {
        mesh.Clear();

        mesh.SetVertices(points);
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
}
