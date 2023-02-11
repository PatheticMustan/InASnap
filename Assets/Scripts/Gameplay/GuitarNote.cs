using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarNote : MonoBehaviour
{
    private GuitarStore store;

    public float timeValue;

    public InputID key;

    public bool press;
    private bool pressChance;

    private float eval;

    private void Awake() {
        GameManager.Instance.keyPress.AddListener(PressNote);
        pressChance = true;
        store = FindObjectOfType<GuitarStore>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        eval = GameManager.Instance.gameTime - timeValue;
        if (!press && pressChance && Mathf.Abs(eval) <= 0f) {
            PressNote(GameManager.Instance.currentKey);
            pressChance = false;
        }

    }

    public void PressNote(InputID id) {
        eval = GameManager.Instance.gameTime - timeValue;
        if (id == key && Mathf.Abs(eval) <= .2f) {
            
        }
    }
}
