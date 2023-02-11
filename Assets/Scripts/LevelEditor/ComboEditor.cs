using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class ComboEditor : EditorWindow
{
    private Combo currentCombo;

    [MenuItem("In A Snap/Combo")]
    public static void ShowMyEditor() {
        // This method is called when the user selects the menu item in the Editor
        EditorWindow wnd = GetWindow<ComboEditor>();
        wnd.titleContent = new GUIContent("Combo Editor");
    }

    private void OnGUI() {
        currentCombo = (Combo)EditorGUILayout.ObjectField("Combo", currentCombo, typeof(Combo), false);
        EditorGUILayout.Space(100);
        if (currentCombo == null) {
            if (GUILayout.Button("Create New Combo")) {
                CreateCombo();
            }
        } else {
            for (int i = 0; i < currentCombo.data.Length; i++) {
                currentCombo.data[i] = CreateMoveState(currentCombo.data[i]);
                EditorGUILayout.Space(30);
            }
        }

    }

    private MoveState CreateMoveState(MoveState moveState) {
        moveState.type = (MoveStateType)EditorGUILayout.EnumFlagsField("Move State Type", moveState.type);

        moveState.key = (InputID)EditorGUILayout.EnumFlagsField("Key", moveState.key);
        if (moveState.type != MoveStateType.Single) {
            moveState.extraKey = (InputID)EditorGUILayout.EnumFlagsField("Extra Key", moveState.extraKey);
        }

        EditorGUILayout.BeginHorizontal();

        moveState.minDuration = EditorGUILayout.FloatField("Min Duration", moveState.minDuration);
        moveState.maxDuration = EditorGUILayout.FloatField("Max Duration", moveState.maxDuration);

        EditorGUILayout.EndHorizontal();

        return moveState;
    }

    private void CreateCombo() {
        Combo combo = (Combo)CreateInstance(typeof(Combo));

        string path = "Assets/Combos/NewCombo.asset";
        AssetDatabase.CreateAsset(combo, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();

        Selection.activeObject = combo;

        currentCombo = combo;
    }
}
