﻿using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(TakeScreenshot))]
public class TakeScreenshotEditor : Editor
{
    TakeScreenshot targetScript;
    void OnEnable()
    {
        targetScript = (TakeScreenshot)target;
        if (targetScript.resulutionList == null)
        {
            targetScript.resulutionList = new System.Collections.Generic.List<CustomResolution>();
            targetScript.resulutionList.Add(new CustomResolution(1920, 1080));
        }
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        EditorGUILayout.LabelField("Screenshot dimensions:");
        for (int i = 0; i < targetScript.resulutionList.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            targetScript.resulutionList[i].width = EditorGUILayout.IntField(targetScript.resulutionList[i].width);
            EditorGUILayout.LabelField("x", GUILayout.MaxWidth(10));
            targetScript.resulutionList[i].height = EditorGUILayout.IntField(targetScript.resulutionList[i].height);
            if (GUILayout.Button("Remove"))
            {
                targetScript.resulutionList.RemoveAt(i);
            }
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Add Resolution"))
        {
            targetScript.resulutionList.Add(new CustomResolution(0, 0));
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Open Screenshots Folder"))
        {
            string path = Application.persistentDataPath + "/" + targetScript.folderName + "/";
            Debug.Log(path);
            EditorUtility.RevealInFinder(path);
        }

        EditorGUILayout.Space();

        targetScript.keyToPress = (KeyCode)EditorGUILayout.EnumPopup("Key for screenshot:", targetScript.keyToPress);

        if (GUI.changed)
        {
            EditorUtility.SetDirty(targetScript);
            EditorSceneManager.MarkSceneDirty(targetScript.gameObject.scene);
        }
    }
}
