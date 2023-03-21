using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarNote : MonoBehaviour
{
    private GuitarStore store;

    public int level;
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
            transform.eulerAngles = 45 * ((int)key-1) * Vector3.forward;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (level == store.levelPos) {
            eval = GameManager.Instance.gameTime - timeValue;
            transform.localPosition = store.NotePosition(eval);
            if (!press && pressChance && eval >= 0f) {
                //Debug.Log("What? " + GameManager.Instance.currentKey);
                //GameManager.Instance.NoteHit(eval / .2f);
                //PressNote(GameManager.Instance.currentKey);
                pressChance = false;
                NoteHit(eval);
            }
        }
        

    }

    public void PressNote(InputID id) {
        //Debug.Log("Press");
        if (level == store.levelPos && press) {
            eval = GameManager.Instance.gameTime - timeValue;
            if (id == key && Mathf.Abs(eval) <= .2f) {
                NoteHit(eval);
            }
        }
    }

    public void NoteHit(float eval) {
        store.PlayGuitar(key, !press);
        GameManager.Instance.NoteHit(eval / .2f);
        gameObject.SetActive(false);
    }
}
