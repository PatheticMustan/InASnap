using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatmapScript : MonoBehaviour {
    public int level;

    public Beat[] beatmap;
    public GameObject beatPrefab;
    public GameObject linePrefab;

    // redArrow, blueArrow, redA, blueA
    public Sprite[] sprites;

    public bool CheckAheadHold(int pos) {
        return !(pos + 1 >= beatmap.Length) && !beatmap[pos + 1].press;
    }

    void Awake() {
        int range = 0;
        int init = -1;
        GameObject[] objs = new GameObject[0];
        GuitarConnector connect = null;

        for (int i = 0; i < beatmap.Length; i++) {
            GameObject beat = Instantiate(beatPrefab, Vector3.zero, Quaternion.identity);
            Beat beatInfo = beatmap[i];
            beat.transform.SetParent(transform);
            beat.GetComponent<GuitarNote>().Setup(beatInfo.timeValue, beatInfo.key, beatInfo.press);

            // set sprite
            if ((int)beatInfo.key >= 1 && (int)beatInfo.key <= 8) {
                // set orientation if it's an arrow
                beat.transform.eulerAngles = 45 * ((int)beatmap[i].key - 1) * Vector3.forward;

                beat.GetComponent<SpriteRenderer>().sprite = sprites[beatInfo.press ? 0 : 1];
            } else if (beatInfo.key.Equals(InputID.A)) {
                //Debug.Log(beatInfo.timeValue);
                beat.GetComponent<SpriteRenderer>().sprite = sprites[beatInfo.press ? 2 : 3];
                beat.GetComponent<Animator>().enabled = true;
            } else if (beatInfo.key.Equals(InputID.B)) {
                // TODO: create B sprites
                // beat.GetComponent<SpriteRenderer>().sprite = sprites[beatmap[i].press ? 4 : 5];
            }

            beat.SetActive(false);
            if (i > init + range && CheckAheadHold(i)) {
                init = i;
                range = 1;
                while (CheckAheadHold(i + range)) {
                    range++;
                }
                
                objs = new GameObject[range + 1];
                objs[0] = beat;

                connect = Instantiate(linePrefab).GetComponent<GuitarConnector>();

            } else if (i > init + range){
                range = 0;
            }
            else if (i == init + range) {
                objs[range] = beat;
                connect.AddLine(objs);
            } else {
                objs[i - init] = beat;
            }
            

            
        }
    }
}

[System.Serializable]
public struct Beat {
    public float timeValue;
    public InputID key;
    public bool press;
}