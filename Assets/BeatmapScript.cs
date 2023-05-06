using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatmapScript : MonoBehaviour {
    public int level;
    
    public Beat[] beatmap;
    public GameObject beatPrefab;

    // redArrow, blueArrow, redA, blueA
    public Sprite[] sprites;

    void Start() {
        for (int i = 0; i < beatmap.Length; i++) {
            GameObject beat = Instantiate(beatPrefab, Vector3.zero, Quaternion.identity);
            Beat beatInfo = beatmap[i];
            beat.transform.SetParent(transform);
            beat.GetComponent<GuitarNote>().Setup(beatInfo.timeValue, beatInfo.key, beatInfo.press);

            Debug.Log(level + ": " + beatInfo.timeValue + ", " + beatInfo.key + " " + beatInfo.key.Equals(InputID.A));

            // set sprite
            if ((int)beatInfo.key >= 1 && (int)beatInfo.key <= 8) {
                // set orientation if it's an arrow
                beat.transform.eulerAngles = 45 * ((int)beatmap[i].key - 1) * Vector3.forward;

                beat.GetComponent<SpriteRenderer>().sprite = sprites[beatInfo.press ? 0 : 1];
            } else if (beatInfo.key.Equals(InputID.A)) {
                Debug.Log(beatInfo.timeValue);
                beat.GetComponent<SpriteRenderer>().sprite = sprites[beatInfo.press ? 2 : 3];
            } else if (beatInfo.key.Equals(InputID.B)) {
                // TODO: create B sprites
                // beat.GetComponent<SpriteRenderer>().sprite = sprites[beatmap[i].press ? 4 : 5];
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