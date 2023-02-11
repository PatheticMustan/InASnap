using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarStore : MonoBehaviour
{
    public DialogueReader reader;
    public Dialogue[] dialogues;
    public GameObject[] levelStore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 NotePosition(float eval) {
        return Vector3.left * eval * 2f;
    }

    public void StartLevel(int id) {
        for (int i = 0; i < dialogues.Length; i++) {
            levelStore[i].SetActive(id == i);
        }

        reader.ReadDialogue(dialogues[id]);
    }
}
