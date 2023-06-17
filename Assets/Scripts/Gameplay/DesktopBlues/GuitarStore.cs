using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarStore : MonoBehaviour
{
    public GameObject hitSquare;
    public HealthbarScript health;

    public DialogueReader reader;
    public float[] length;
    public Dialogue[] dialogues;
    public Dialogue[] randomDeath;
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
                health.ResetHealth();
            }
            
        }
    }

    public Vector3 NotePosition(float eval) {
        return eval * 8f * Vector3.left;
    }

    public void SetUpLevel(int id) {
        for (int i = 0; i < dialogues.Length; i++) {
            levelStore[i].SetActive(id == i);
            if (id == i) {
                for (int j = 0; j < levelStore[i].transform.childCount; j++) {
                    levelStore[i].transform.GetChild(j).GetComponent<GuitarNote>().ResetNote();
                }
            }
        }

        levelPos = id;
        GameManager.Instance.gameTime = 0;
        GameManager.Instance.isPlaying = false;
    }

    public void StartLevel(int id) {
        SetUpLevel(id);

        reader.ReadDialogue(dialogues[id]);
    }

    public void Retry() {
        SetUpLevel(levelPos);

        reader.ReadDialogue(randomDeath[Random.Range(0,randomDeath.Length)]);
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
