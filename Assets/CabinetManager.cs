using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CabinetManager : MonoBehaviour
{
    public CabinetShoot player;
    public Animator friend;

    public bool playerRight;
    public bool temp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (temp) {
            Switch();
            temp = false;
        }
    }

    public void Switch() {
        if (playerRight) {
            player.transform.DOMove(Vector3.left * .6f, .1f);
            friend.transform.DOJump(Vector3.right * .6f, 1.5f, 1, .2f).SetEase(Ease.OutSine);
        } else {
            friend.transform.DOJump(Vector3.left * .6f,1.5f,1, .2f).SetEase(Ease.OutSine);
            player.transform.DOMove(Vector3.right * .6f, .1f);
        }
        playerRight = !playerRight;
        player.isRight = playerRight;
    }
}
