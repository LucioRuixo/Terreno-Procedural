using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MapGenerator mapGenerator = (MapGenerator)target;

        if ((DrawDefaultInspector() && mapGenerator.autoUpdate) || GUILayout.Button("Generate")) mapGenerator.Generate();
    }
}

[CustomEditor(typeof(MapDisplay))]
public class MapDisplayEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MapDisplay mapDisplay = (MapDisplay)target;

        if ((DrawDefaultInspector() && mapDisplay.autoUpdate)) mapDisplay.mapGenerator.Generate();
    }
}