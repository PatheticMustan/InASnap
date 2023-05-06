using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarNote : MonoBehaviour {
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

    public void Setup(float timeValue, InputID key, bool press) {
        this.timeValue = timeValue;
        this.key = key;
        this.press = press;
    }

    void FixedUpdate() {
        eval = GameManager.Instance.gameTime - timeValue;
        transform.localPosition = store.NotePosition(eval);

        if (!press && GameManager.Instance.currentKey == key && pressChance && eval >= 0f) {
            pressChance = false;
            NoteHit(eval);
        }

        if (eval >= .2f) {
            GameManager.Instance.NoteMiss();
            gameObject.SetActive(false);
        }
    }

    public void PressNote(InputID id) {
        if (press && pressChance) {
            eval = GameManager.Instance.gameTime - timeValue;
            if (id == key && Mathf.Abs(eval) <= .2f) {
                pressChance = false;
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
