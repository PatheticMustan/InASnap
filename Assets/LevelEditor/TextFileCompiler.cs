using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;


public class TextFileCompiler : MonoBehaviour
{
    public Transform parentObj;
    public TMP_InputField bpm;

    public void CompileSong(string name) {
        string path = Application.dataPath + "/LevelData/" + name + ".txt";
        string data = "";
        BeatMapData bmp = new BeatMapData {
            lastEditDate = System.DateTime.Now.ToString(),
            bpm = float.Parse(bpm.text) };
        data += JsonUtility.ToJson(bmp) + "\n";

        for (int i = 0; i < parentObj.childCount; i++) {
            //Add Data from each object
            EditorNoteObject noteObject = parentObj.GetChild(i).GetComponent<EditorNoteObject>();
            data += JsonUtility.ToJson(noteObject.GetNoteData()) + "\n";
        }

        File.WriteAllText(path, data);
    }
}

public class BeatMapData{

    public string lastEditDate;
    public float bpm;

}