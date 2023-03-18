using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorNoteObject : MonoBehaviour
{
    //Object that represents how long a note is
    public GameObject lengthObject;
    public int objectLevel;
    public int objectID;

    public void SetupNote(EditorNoteData noteData) {
        transform.position = Vector3.right * noteData.position;
        objectLevel = noteData.level;
        objectID = noteData.objID;
    }

    public EditorNoteData GetNoteData() {
        return new EditorNoteData {
            position = transform.position.x,
            level = objectLevel,
            objID = objectID
        };
    }
}

public class EditorNoteData {
    public float position;
    public int level;
    public int objID;
}
