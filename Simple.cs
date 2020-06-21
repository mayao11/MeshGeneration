using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple : MonoBehaviour
{
    public float width = 0.1f;

    MeshRenderer meshRenderer;
    MeshFilter meshFilter;
    MeshCollider meshCollider;

    // 用来存放顶点数据
    List<Vector3> verts;
    List<int> indices;

    private void Start()
    {
        verts = new List<Vector3>();
        indices = new List<int>();

        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();
        meshCollider = GetComponent<MeshCollider>();

        Generate();
    }

    public void Generate()
    {
        ClearMeshData();

        // 把数据填写好
        AddMeshData();

        // 把数据传递给Mesh，生成真正的网格
        Mesh mesh = new Mesh();
        mesh.vertices = verts.ToArray();
        //mesh.uv = uvs.ToArray();
        mesh.triangles = indices.ToArray();

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        meshFilter.mesh = mesh;
        // 碰撞体专用的mesh，只负责物体的碰撞外形
        meshCollider.sharedMesh = mesh;
    }

    void ClearMeshData()
    {
        verts.Clear();
        indices.Clear();
    }

    void AddMeshData()
    {
        verts.Add(new Vector3(0, 0, 0));
        verts.Add(new Vector3(0, 0, 1));
        verts.Add(new Vector3(1, 0, 1));
        verts.Add(new Vector3(1, 0, 0));

        indices.Add(0);  indices.Add(1);  indices.Add(2);
        indices.Add(0);  indices.Add(2);  indices.Add(3);
    }
    
}

