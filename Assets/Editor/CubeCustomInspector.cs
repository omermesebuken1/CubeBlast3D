using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(CubeCreator))]
[CanEditMultipleObjects]
public class CubeCustomInspector : Editor
{
    SerializedProperty CubePrefab;
    SerializedProperty BoxPrefab;
    SerializedProperty CubeParentPrefab;
    SerializedProperty distance;
    SerializedProperty xCount;
    SerializedProperty yCount;
    SerializedProperty zCount;
    SerializedProperty colorCode;
  
    

    private void OnEnable() {
        
         CubePrefab = serializedObject.FindProperty("CubePrefab");
         BoxPrefab = serializedObject.FindProperty("BoxPrefab");
         CubeParentPrefab = serializedObject.FindProperty("CubeParentPrefab");
         distance = serializedObject.FindProperty("distance");
         xCount = serializedObject.FindProperty("xCount");
         yCount = serializedObject.FindProperty("yCount");
         zCount = serializedObject.FindProperty("zCount");
         colorCode = serializedObject.FindProperty("colorCode");
         
         
    }

    public override void OnInspectorGUI()
    {
        GUILayout.Label ("THE CUBE CREATOR");
        GUILayout.Label ("");

        serializedObject.Update();

        EditorGUILayout.PropertyField(CubePrefab); 
        EditorGUILayout.PropertyField(BoxPrefab);     
        EditorGUILayout.PropertyField(CubeParentPrefab);
        
        
        GUILayout.Label ("");
        GUILayout.Label ("SETTINGS");
        
        EditorGUILayout.PropertyField(distance);
        EditorGUILayout.PropertyField(xCount);
        EditorGUILayout.PropertyField(yCount);
        EditorGUILayout.PropertyField(zCount);
        GUILayout.Label ("");
        EditorGUILayout.PropertyField(colorCode);
        GUILayout.Label("  0 = Random     1 = Red    2 = Blue    3 = Green    4 = Yellow");
        


        
        serializedObject.ApplyModifiedProperties();


        GUILayout.Label ("");
        GUILayout.Label ("");
        GUILayout.Label ("");
        

        CubeCreator cubeCreator = (CubeCreator)target;

        if(GUILayout.Button("Create Cubes"))
        {
            cubeCreator.TheCubeCreator();
        }

        if(GUILayout.Button("Create Boxes"))
        {
            cubeCreator.TheBoxCreator();
        }





        


    }
    


}
