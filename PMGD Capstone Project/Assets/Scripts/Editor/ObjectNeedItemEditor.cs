using UnityEditor;
using UnityEngine;
using System;

[CustomEditor(typeof(ObjectNeedItem))]
public class ObjectNeedItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ObjectNeedItem objectNeedItem = (ObjectNeedItem)target;

        DrawDefaultInspector();

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Custom Settings", EditorStyles.boldLabel);

        int itemArraySize = EditorGUILayout.IntField("Item Name Array Size", objectNeedItem.itemName.Length);
        if (itemArraySize != objectNeedItem.itemName.Length)
        {
            Array.Resize(ref objectNeedItem.itemName, itemArraySize);
        }

        for (int i = 0; i < objectNeedItem.itemName.Length; i++)
        {
            objectNeedItem.itemName[i] = EditorGUILayout.TextField("Item Name " + i, objectNeedItem.itemName[i]);
        }

        objectNeedItem.destroyItem = EditorGUILayout.Toggle("Destroy Item", objectNeedItem.destroyItem);
        objectNeedItem.isASwitchObj = EditorGUILayout.Toggle("Is a Switch Object", objectNeedItem.isASwitchObj);

        EditorGUILayout.LabelField("Change Dialogue", EditorStyles.boldLabel);
        objectNeedItem.isChangeDialogue = EditorGUILayout.Toggle("Change Dialogue", objectNeedItem.isChangeDialogue);
        if (objectNeedItem.isChangeDialogue)
        {
            objectNeedItem.isParentDialogue = EditorGUILayout.Toggle("Is Parent Dialogue", objectNeedItem.isParentDialogue);
            objectNeedItem.dialogueTrigger = (DialogueTrigger)EditorGUILayout.ObjectField("Dialogue Trigger", objectNeedItem.dialogueTrigger, typeof(DialogueTrigger), true);
            objectNeedItem.forceStart = EditorGUILayout.Toggle("Force Start Dialogue", objectNeedItem.forceStart);
        }

        EditorGUILayout.LabelField("Activate Object", EditorStyles.boldLabel);
        objectNeedItem.isActivateObj = EditorGUILayout.Toggle("Activate Object", objectNeedItem.isActivateObj);
        if (objectNeedItem.isActivateObj)
        {
            objectNeedItem.objToActivate = (GameObject)EditorGUILayout.ObjectField("Object to Activate", objectNeedItem.objToActivate, typeof(GameObject), true);
        }

        EditorGUILayout.LabelField("Requirement", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Status", EditorStyles.boldLabel);
    }
}
