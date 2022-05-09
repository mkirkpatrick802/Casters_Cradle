using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Item), true)]
[CanEditMultipleObjects]
public class ItemEditor : Editor
{
    new SerializedProperty name;
    SerializedProperty icon;
    SerializedProperty itemType;
    SerializedProperty isStackable;
    SerializedProperty amount;

    protected virtual void OnEnable()
    {
        name = serializedObject.FindProperty("name");
        icon = serializedObject.FindProperty("icon");
        itemType = serializedObject.FindProperty("itemType");
        isStackable = serializedObject.FindProperty("isStackable");
        amount = serializedObject.FindProperty("amount");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(name);
        EditorGUILayout.PropertyField(icon);
        EditorGUILayout.PropertyField(itemType);

        switch (itemType.enumValueFlag)
        {
            case (int)ItemType.Gold:
            case (int)ItemType.SpellComponent:
                EditorGUILayout.PropertyField(isStackable);
                if (isStackable.boolValue == true)
                {
                    EditorGUILayout.PropertyField(amount);
                }

                break;
            default:
                break;
        }


        serializedObject.ApplyModifiedProperties();
    }
}
