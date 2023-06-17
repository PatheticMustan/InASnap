using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CabinetEnemy : MonoBehaviour
{
    public float speed;
    public int enemyType;
    public bool rightSide;
    public int hp;
    public bool flying;

    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        //SpawnEnemy(rightSide, flying);
    }

    public void SpawnEnemy(float timer, bool right, bool fly, bool type) {
        rightSide = right;
        flying = fly;
        enemyType = type ? 1 : 0;

        transform.position = new Vector3((rightSide ? 1 : -1) * (timer * speed +1f), (fly ? 3 : 0));
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (flying && Mathf.Abs(transform.position.x) < 2) {
            flying = false;
            transform.DOMoveY(0, .2f);
        }
        transform.position += (-transform.position.x * Vector3.right).normalized * speed * Time.deltaTime;
    }

    public void Damage(int damageType) {
        
        if (damageType == enemyType) {
            hp--;
            if (hp <= 0) {
                Defeat();
            } else {
                Knockback();
            }
        }
        
    }

    public void Knockback() {
        canMove = false;
        transform.DOMoveX(transform.position.x + (rightSide ? 1 : -1) * 2f, .5f).SetEase(Ease.OutSine).OnComplete(() => canMove = true);
        Debug.Log("Get Back, back again");
    }

    public void Defeat() {
        transform.DOScale(Vector3.zero, .1f);
        canMove = false;
        Debug.Log("YOW");
    }
}
