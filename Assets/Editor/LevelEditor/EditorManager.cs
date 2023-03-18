using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorManager : MonoBehaviour
{
    [SerializeField]
    private GameObject notePrefab;

    private Transform selectionDisplay;
    private EditorNoteObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedObject != null) {
            selectionDisplay.position = selectedObject.transform.position;
        }
    }
}
