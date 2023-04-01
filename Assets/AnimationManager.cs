using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {
    public Animator character;

    private void Awake() {
        GameManager.Instance.KeyAddListener(TestAnimation);
    }

    void Update() {}


    // i love how funny this looks
    public void TestAnimation(InputID id) {
        switch (id) {
            case InputID.Up:
                character.SetBool("Jamming", true);
                character.SetInteger("JammingDirection", 0);
                character.SetBool("Jazz", false);
                break;
            case InputID.Down:
                character.SetBool("Jamming", true);
                character.SetInteger("JammingDirection", 1);
                character.SetBool("Jazz", false);
                break;
            case InputID.Left:
            case InputID.Leftdown:
            case InputID.Leftup:
                character.SetBool("Jamming", true);
                character.SetInteger("JammingDirection", 2);
                character.SetBool("Jazz", false);
                break;
            case InputID.Right:
            case InputID.Rightdown:
            case InputID.Rightup:
                character.SetBool("Jamming", true);
                character.SetInteger("JammingDirection", 3);
                character.SetBool("Jazz", false);
                break;
            case InputID.A:
                character.SetBool("Jazz", true);
                break;
            default:
                character.SetBool("Jamming", false);
                character.SetBool("Jazz", false);
                break;
        }
    }
}