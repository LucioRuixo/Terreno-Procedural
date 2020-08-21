using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapManager))]
public class MapManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MapManager mapManager = (MapManager)target;

        if ((DrawDefaultInspector() && mapManager.autoUpdate) || GUILayout.Button("Generate")) mapManager.Generate();
    }
}