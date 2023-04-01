using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetShoot : MonoBehaviour
{
    public ParticleSystem fireball;
    public ParticleSystem hammer;

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
