using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetProjectile : MonoBehaviour
{
    public int type;

    private void OnParticleCollision(GameObject other) {
        other.GetComponent<CabinetEnemy>().Damage(type);
    }
}
