using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetShoot : MonoBehaviour
{
    public ParticleSystem fireball;
    public ParticleSystem hammer;

    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        ComboReader.comboHit.AddListener(Shoot);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(int id) {
        if (id % 2 == (isRight ? 0 : 1))
        switch (id) {
            case 0:
            case 1:
                fireball.transform.eulerAngles = Vector3.forward * (id % 2 * 180);
                fireball.Play();
                break;
            case 2:
            case 3:
                hammer.transform.eulerAngles = Vector3.up * (id % 2 * 180);
                hammer.Play();
                break;
        }
    }
}
