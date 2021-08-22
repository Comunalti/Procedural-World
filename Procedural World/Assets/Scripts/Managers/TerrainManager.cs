using System;
using UnityEngine;

namespace Managers
{
    public class TerrainManager : Singleton<TerrainManager>
    {
        private GameObject map;
        public Vector3Int size;
        public Mesh mapMesh;
        public MeshFilter meshFilter;

        public int[] triangleArray;
        public Vector3[] verticesArray;
        [ContextMenu("Recreate Mesh")]
        private void ReCreateMesh()
        {
            mapMesh = new Mesh();
            mapMesh.vertices = GetVertices();
            mapMesh.triangles = GetTriangles();
            mapMesh.RecalculateNormals();
            meshFilter.mesh = mapMesh;
        }

        private int[] GetTriangles()
        {
            triangleArray = new int[size.x * size.z * 6];
            for (int x = 0; x < size.x; x++)
            {
                for (int z = 0; z < size.y; z++)
                {
                    FillVerticesTriangle(triangleArray,x,z);
                }
            }
            return triangleArray;
        }

        private void FillVerticesTriangle(int[] triangleArray, int x,int z)
        {
        }

        private Vector3[] GetVertices()
        {
            verticesArray = new Vector3[size.x * size.z];
            for (int x = 0; x < size.x; x++)
            {
                for (int z = 0; z < size.y; z++)
                {
                    var noiseValue = Mathf.PerlinNoise(x, z);
                    var y = noiseValue * size.y;
                    verticesArray[Linearize2DArray(x, z)] = new Vector3(x, y, z);
                }
            }
            return verticesArray;
        }

        private int Linearize2DArray(int x, int z)
        {
            return Mathf.FloorToInt(((x % size.x) * size.x + (z % size.z)));
        }

        private void Start()
        {
            map = new GameObject("Map");
            meshFilter = map.AddComponent<MeshFilter>();
            map.AddComponent<MeshRenderer>();
        }
        
    }
}
