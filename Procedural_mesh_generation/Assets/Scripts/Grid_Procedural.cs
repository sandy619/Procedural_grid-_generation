using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid_Procedural : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;

    //grid settings
    public float cellsize = 1;
    public Vector3 gridoffset;
    public int gridsize;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    // Start is called before the first frame update
    void Start()
    {
        MakeDiscreteProceduralGrid();
        UpdateMesh();
    }

    void Update()
    {
        MakeDiscreteProceduralGrid();
        UpdateMesh();
    }

void MakeDiscreteProceduralGrid()
    {
        vertices = new Vector3[gridsize * gridsize * 4];
        triangles = new int[gridsize * gridsize * 6];

        //trakcer ints
        int v = 0;
        int t = 0;

        float vertexOffset = cellsize * 0.5f;

        for (int x = 0; x < gridsize; x++)
        {
            for (int y = 0; y < gridsize; y++)
            {
                Vector3 cellOffset = new Vector3(x * cellsize, 0, y * cellsize);
                //populate the vertices and triangle arrays
                vertices[v] = new Vector3(-vertexOffset, 0, -vertexOffset) + cellOffset + gridoffset;
                vertices[v + 1] = new Vector3(-vertexOffset, 0, vertexOffset) + cellOffset + gridoffset;
                vertices[v + 2] = new Vector3(vertexOffset, 0, -vertexOffset) + cellOffset + gridoffset;
                vertices[v + 3] = new Vector3(vertexOffset, 0, vertexOffset) + cellOffset + gridoffset;

                triangles[t] = v;
                triangles[t + 1] = triangles[t + 4] = v + 1;
                triangles[t + 2] = triangles[t + 3] = v + 2;
                triangles[t + 5] = v + 3;

                v += 4;
                t += 6;
            }
        }


    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    // Update is called once per frame
}
