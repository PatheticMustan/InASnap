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
        GameManager.Instance.KeyAddListener(PressNote);
        pressChance = true;
        store = FindObjectOfType<GuitarStore>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if ((int)key >= 1 && (int)key <= 9) {
            transform.eulerAngles = Vector3.forward * 45 * ((int)key-1);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        eval = GameManager.Instance.gameTime - timeValue;
        transform.localPosition = store.NotePosition(eval);
        if (!press && pressChance && eval >= 0f) {
            Debug.Log("What? " + GameManager.Instance.currentKey);
            PressNote(GameManager.Instance.currentKey);
            pressChance = false;
        }

    }

    public void PressNote(InputID id) {
        Debug.Log("Press");
        eval = GameManager.Instance.gameTime - timeValue;
        if (id == key && Mathf.Abs(eval) <= .2f) {
            gameObject.SetActive(false);
        }
    }
}
