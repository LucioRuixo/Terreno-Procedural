using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public enum DisplayModes
    {
        HeightMap,
        ColorMap
    }

    [SerializeField] DisplayModes displayMode = DisplayModes.HeightMap;

    [SerializeField] Renderer textureRenderer = null;
    public MapGenerator mapGenerator = null;

    public bool autoUpdate = true;

    public void Draw(float[,] noiseMap, Color[] colorMap)
    {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);

        Texture2D texture;
        if (displayMode == DisplayModes.ColorMap) texture = TextureGenerator.GenerateTextureFromColorMap(colorMap, width, height);
        else texture = TextureGenerator.GenerateTextureFromHeightMap(noiseMap);

        textureRenderer.sharedMaterial.mainTexture = texture;
        textureRenderer.transform.localScale = new Vector3(width, 1, height);
    }
}