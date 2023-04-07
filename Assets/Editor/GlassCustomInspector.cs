using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(GlassCreator))]
[CanEditMultipleObjects]
public class GlassCustomInspector : Editor
{
    SerializedProperty glassPrefab;
    SerializedProperty cubeSpace;

    SerializedProperty positionX;
    SerializedProperty positionY;
    SerializedProperty positionZ;

    SerializedProperty scaleX;
    SerializedProperty scaleY;
    SerializedProperty scaleZ;
  
    

    private void OnEnable() {
        
         glassPrefab = serializedObject.FindProperty("glassPrefab");
         cubeSpace = serializedObject.FindProperty("cubeSpace");
         positionX = serializedObject.FindProperty("positionX");
         positionY = serializedObject.FindProperty("positionY");
         positionZ = serializedObject.FindProperty("positionZ");
         scaleX = serializedObject.FindProperty("scaleX");
         scaleY = serializedObject.FindProperty("scaleY");
         scaleZ = serializedObject.FindProperty("scaleZ");
         
         
    }

    public override void OnInspectorGUI()
    {
        GUILayout.Label ("THE GLASS CREATOR");
        GUILayout.Label ("");

        serializedObject.Update();

        EditorGUILayout.PropertyField(glassPrefab); 
           
        GUILayout.Label ("");
        GUILayout.Label ("SETTINGS");
        GUILayout.Label ("");

        EditorGUILayout.PropertyField(cubeSpace);  
        GUILayout.Label ("");
        
        EditorGUILayout.PropertyField(positionX);
        EditorGUILayout.PropertyField(positionY);
        EditorGUILayout.PropertyField(positionZ);

        GUILayout.Label ("");

        EditorGUILayout.PropertyField(scaleX);
        EditorGUILayout.PropertyField(scaleY);
        EditorGUILayout.PropertyField(scaleZ);
        
        serializedObject.ApplyModifiedProperties();


        GUILayout.Label ("");
        GUILayout.Label ("");
        GUILayout.Label ("");
        

        GlassCreator glassCreator = (GlassCreator)target;

        if(GUILayout.Button("Create Glass"))
        {
            glassCreator.TheGlassCreator();
        }



    }
    


}
