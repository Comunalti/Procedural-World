using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Managers
{
    public class TerrainManager : Singleton<TerrainManager>
    {
    //todo: Watch and copy past Sebastian code
    // i need to learn some marching cubes algorithm
    //i am want to apply this algorithm here and later use some flocking algorithm
        public Material material;
        private GameObject map;
        public Vector3Int size;
        public Mesh mapMesh;
        public MeshFilter meshFilter;

        public float frequency = 0.4f;

        public Texture2D texture;
        
        public int[] triangleArray;
        public Vector3[] verticesArray;
        public int octaveCount = 1;

        [ContextMenu("Recreate Mesh")]
        private void ReCreateMesh()
        {
            float time = Time.time;
            mapMesh = new Mesh();
            mapMesh.indexFormat = IndexFormat.UInt32;
            BuildArrays();
            mapMesh.vertices = verticesArray;
            mapMesh.triangles = triangleArray;
            mapMesh.RecalculateNormals();
            meshFilter.mesh = mapMesh;
            print(Time.time - time);
        }


        private void BuildArrays()
        {
            var verticesList = new List<Vector3>();
            var trianglesList = new List<int>();
            texture = new Texture2D(size.x, size.z);
            texture.filterMode = FilterMode.Point;
            texture.anisoLevel = 0;
            for (int x = 0; x < size.x; x++)
            {
                for (int z = 0; z < size.z; z++)
                {
                    
                    verticesList.Add(GetNoiseVector(x,z));
                    verticesList.Add(GetNoiseVector(x+1,z));
                    verticesList.Add(GetNoiseVector(x,z+1));
                    verticesList.Add(GetNoiseVector(x+1,z+1));
                    
                    trianglesList.Add(verticesList.Count-4);
                    trianglesList.Add(verticesList.Count-2);
                    trianglesList.Add(verticesList.Count-3);
                    trianglesList.Add(verticesList.Count-3);
                    trianglesList.Add(verticesList.Count-2);
                    trianglesList.Add(verticesList.Count-1);
                }
            }
            verticesArray = verticesList.ToArray();
            triangleArray = trianglesList.ToArray();
            texture.Apply();
        }

        private Vector3 GetNoiseVector(int x, int z)
        {
            
            float y = 0;
            for (int i = 0; i < octaveCount; i++)
            {
                var value = Mathf.Pow(2, i);
                y += Mathf.PerlinNoise(x / (value * frequency), z / (value * frequency))/value;
            }
            
            texture.SetPixel(x,z,new Color(y,y,y));
            return new Vector3(x,y* size.y, z);
        }
        

     

        private void Start()
        {
            map = new GameObject("Map");
            meshFilter = map.AddComponent<MeshFilter>();
            var render = map.AddComponent<MeshRenderer>();
            render.material = material;
        }
    }
}
