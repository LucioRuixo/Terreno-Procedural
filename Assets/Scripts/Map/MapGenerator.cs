using System;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Serializable]
    public struct TerrainType
    {
        public string name;

        public float height;

        public Color color;
    }

    [SerializeField] TerrainType[] terrainTypes = null;

    [SerializeField] int mapWidth = 100;
    [SerializeField] int mapHeight = 100;
    [SerializeField] float noiseScale = 1.0f;

    [SerializeField] int octaves = 3;
    [Range(0, 1)]
    [SerializeField] float persistence = 0.5f;
    [SerializeField] float lacunarity = 2;

    [SerializeField] int seed = 061200;
    [SerializeField] Vector2 offset = Vector2.zero;

    [SerializeField] MapDisplay mapDisplay = null;

    public bool autoUpdate = true;

    public void Generate()
    {
        float[,] noiseMap = PerlinNoiseGenerator.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistence, lacunarity, offset);

        Color[] colorMap = new Color[mapWidth * mapHeight];
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float currentHeight = noiseMap[x, y];

                for (int i = 0; i < terrainTypes.Length; i++)
                {
                    if (currentHeight <= terrainTypes[i].height)
                    {
                        colorMap[y * mapWidth + x] = terrainTypes[i].color;
                        break;
                    }
                }
            }
        }

        mapDisplay.Draw(noiseMap, colorMap);
    }

    private void OnValidate()
    {
        if (mapWidth < 1) mapWidth = 1;
        if (mapHeight < 1) mapHeight = 1;
        if (lacunarity < 1) lacunarity = 1;
        if (octaves < 0) octaves = 0;
    }
}