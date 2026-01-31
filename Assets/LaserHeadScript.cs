using System.Collections.Generic;
using UnityEngine;

public class LaserHeadScript : MonoBehaviour
{
    private Mesh mesh;
    private MeshFilter meshFilter;
    [SerializeField] private List<Vector3> facePoints = new List<Vector3>(4);
    [SerializeField] private Vector3 startingPoint5;
    [SerializeField] private Vector3 startingPoint6;
    [SerializeField] private Vector3 startingPoint7;
    [SerializeField] private Vector3 startingPoint8;

    void Start()
    {
        mesh = new Mesh();
        meshFilter = GetComponentInChildren<MeshFilter>();
        meshFilter.mesh = mesh;

        GenerateMesh(new Vector3[] {startingPoint5, startingPoint6, startingPoint7, startingPoint8, facePoints[0], facePoints[1], facePoints[2], facePoints[3]});
    }

    private void GenerateMesh(Vector3[] points)
    {
        if (points.Length != 8) return;

        mesh.Clear();
        mesh.vertices = points;
        
        int[] triangles = new int[]
        {
            // Ön Yüz (Front)
            0, 4, 1,
            1, 4, 5,

            // Arka Yüz (Back)
            3, 7, 2,
            2, 7, 6,

            // Sol Yüz (Left)
            2, 6, 0,
            0, 6, 4,

            // Sağ Yüz (Right)
            1, 5, 3,
            3, 5, 7,

            // Üst Yüz (Top)
            4, 6, 5,
            5, 6, 7,

            // Alt Yüz (Bottom)
            2, 0, 3,
            3, 0, 1
        };

        mesh.triangles = triangles;

        // UV haritalama 8 vertexli küp için genellikle bozuk görünür 
        // çünkü her vertex 3 farklı yüzey tarafından paylaşılır.
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}
