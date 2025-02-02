using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ControlPos))]
public class ControlPosEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ControlPos myScript = (ControlPos)target;

        if (GUILayout.Button("Save Pos"))
        {
            myScript.SaveObjectPosition();
        }

        if (GUILayout.Button("Save Hint Pos"))
        {
            myScript.SavedHintPosition();
        }
    }
}
