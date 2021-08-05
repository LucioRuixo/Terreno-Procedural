using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public enum DrawModes
    {
        HeightMap,
        ColorMap,
        Mesh
    }

    [SerializeField] DrawModes drawMode = DrawModes.HeightMap;

    [Header("Map Objects")]
    [SerializeField] GameObject mapPlaneObject = null;
    [SerializeField] GameObject mapMeshObject = null;

    [Header("Drawing Components")]
    [SerializeField] Renderer textureRenderer = null;
    [SerializeField] MeshRenderer meshRenderer = null;
    [SerializeField] MeshFilter meshFilter = null;

    public bool autoUpdate = true;
    public MapGenerator mapGenerator = null;

    public void Draw(float[,] noiseMap, Color[] colorMap)
    {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);

        switch (drawMode)
        {
            case DrawModes.ColorMap:
                textureRenderer.sharedMaterial.mainTexture = TextureGenerator.GenerateTextureFromColorMap(colorMap, width, height);
                break;

            case DrawModes.Mesh:
                meshFilter.sharedMesh = MeshGenerator.GenerateTerrainMesh(noiseMap).GenerateMesh();
                meshRenderer.sharedMaterial.mainTexture = TextureGenerator.GenerateTextureFromColorMap(colorMap, width, height);
                break;

            case DrawModes.HeightMap:
            default:
                textureRenderer.sharedMaterial.mainTexture = TextureGenerator.GenerateTextureFromHeightMap(noiseMap);
                break;
        }

        //if (drawMode == DrawModes.Mesh)
        //{
        //    mapPlaneObject.SetActive(false);
        //    mapMeshObject.SetActive(true);
        //}
        //else
        //{
        //    mapMeshObject.SetActive(false);
        //    mapPlaneObject.SetActive(true);
        //}

        textureRenderer.transform.localScale = new Vector3(width, 1, height);
    }
}