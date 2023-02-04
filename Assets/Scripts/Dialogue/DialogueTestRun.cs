using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueReader))]
public class DialogueTestRun : MonoBehaviour
{
    public Dialogue dialogue;
    private DialogueReader dialogueReader;

    // Start is called before the first frame update
    void Start()
    {
        dialogueReader = GetComponent<DialogueReader>();
        dialogueReader.ReadDialogue(dialogue);
    }
}
