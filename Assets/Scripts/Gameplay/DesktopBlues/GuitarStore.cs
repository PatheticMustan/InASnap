using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarStore : MonoBehaviour
{
    public GameObject hitSquare;

    public DialogueReader reader;
    public float[] length;
    public Dialogue[] dialogues;
    public GameObject[] levelStore;

    public Dialogue dialogueEnd;

    public int levelPos;

    public AudioSource pluck;
    public AudioSource pass;
    public AudioSource strum;

    public ParticleSystem pluckPS;
    public ParticleSystem passPS;
    public ParticleSystem strumPS;

    // Start is called before the first frame update
    void Start()
    {
        StartLevel(0);
        levelPos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        InputID key = GameManager.Instance.currentKey;
        if ((int)key >= 1 && (int)key <= 9) {
            hitSquare.transform.eulerAngles = 45 * ((int)key - 1) * Vector3.forward;
        }

        if (GameManager.Instance.isPlaying && GameManager.Instance.gameTime >= length[levelPos]) {
            if (levelPos + 1 == levelStore.Length) {
                GameManager.Instance.isPlaying = false;
                reader.ReadDialogue(dialogueEnd);
            } else {
                levelPos++;
                StartLevel(levelPos);
            }
            
        }
    }

    public Vector3 NotePosition(float eval) {
        return eval * 4f * Vector3.left;
    }

    public void StartLevel(int id) {
        for (int i = 0; i < dialogues.Length; i++) {
            levelStore[i].SetActive(id == i);
        }

        levelPos = id;
        GameManager.Instance.gameTime = 0;
        GameManager.Instance.isPlaying = false;

        reader.ReadDialogue(dialogues[id]);
    }

    public void PlayGuitar(InputID id, bool isPass) {
        if (isPass) {
            pass.Play();
            passPS.Play();
        } else if (id == InputID.A) {
            strum.Play();
            strumPS.Play();
        } else {
            pluck.Play();
            pluckPS.Play();
        }
    }


}