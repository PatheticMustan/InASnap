using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetSpawner : MonoBehaviour
{
    public CabinetWave[] levels;
    public CabinetManager manager;
    public int lev;
    public ObjectPool enemies;
    public ObjectPool bigEnemies;
    public float timer;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        enemies.AddObjects();
        bigEnemies.AddObjects();
        SpawnWave(levels[lev]);
        timer = 0f;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (count < levels[lev].switchTime.Length && timer > levels[lev].switchTime[count]) {
            manager.Switch();
            count++;
        }



    }

    public void SpawnWave(CabinetWave w) {
        enemies.DisableAll();
        for (int i = 0; i < w.wave.Length; i++) {
            CabinetSpawn cs = w.wave[i];
            GameObject obj;
            if (cs.isBig) {
                obj = bigEnemies.GetObject();
            } else {
                obj = enemies.GetObject();
            }

            obj.GetComponent<CabinetEnemy>().SpawnEnemy(cs.time, cs.isRight, cs.isFly, cs.type);
        }
    }
}

[System.Serializable]
public class CabinetWave {
    public CabinetSpawn[] wave;
    public float[] switchTime;
}

[System.Serializable]
public class CabinetSpawn {
    public bool type;
    public bool isRight;
    public bool isBig;
    public bool isFly;
    public float time;
}
