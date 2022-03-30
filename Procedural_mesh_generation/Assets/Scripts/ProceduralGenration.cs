using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class ProceduralGenration : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        MeshData();
        CreateMesh();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Mesh data function
    void MeshData()
    {
        //array of vertices
        vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(0, 0, 1) , new Vector3(0,1,1)};
        //array of triangles
        triangles = new int[] { 0, 1, 2 , 2 , 1 ,3};
    }

    //Function to clear and create mesh
    void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        //mesh.RecalculateNormals();
        
    }
}
