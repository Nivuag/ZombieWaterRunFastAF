using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshWaveComponent : MonoBehaviour
{
    private Vector3[] vertices;
    private Vector3[] verticesOG;
    private Mesh mesh;
    public bool animationOn = false;
    public float amplitude = 0;
    public float frequence = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        mesh  = GetComponent<MeshFilter>().mesh;

        verticesOG = mesh.vertices;

        vertices = new Vector3[verticesOG.Length];
        
    }

    // Update is called once per frame
    void Update()
    {
        int nVertices = vertices.Length;

        for (int i = 0; i < nVertices; i++)
        {
            vertices[i] = verticesOG[i];
        }

        if(animationOn)
        {
            for (int i = 0; i < nVertices; i++)
            {
                vertices[i] += (transform.up *( amplitude * (Mathf.Sin(((2f*Mathf.PI)/frequence)*(vertices[i].x+Time.time)))));
            }
            mesh.vertices = vertices;
            
        }

        
    }
}
