using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarConnector : MonoBehaviour
{
    public GameObject[] targetObjects;
    private List<GameObject> aliveArrows;
    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        aliveArrows = new List<GameObject>();
        line = GetComponent<LineRenderer>();
    }

    public void AddLine(GameObject[] objects) {
        targetObjects = objects;
    }

    // Update is called once per frame
    void Update()
    {
        bool flag = false;
        for (int i = 0; i < targetObjects.Length; i++) {
            if (targetObjects[i].activeSelf)
                flag = true;
        }
        
        if (flag) {
            //Debug.Log("Win");
            line.positionCount = targetObjects.Length;
            for (int i = 0; i < targetObjects.Length; i++) {
                
                line.SetPosition(i, targetObjects[i].activeSelf ? targetObjects[i].transform.position : new Vector3(-8,-4.5f));
            }
        } else {
            line.positionCount = 0;
        }
        
    }
}
