using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void KeyPress(InputID id);

public class GameManager : InputReciever
{

    private static GameManager inst;
    public static GameManager Instance { get { if (inst == null) { inst = FindObjectOfType<GameManager>(); } return inst; } private set {; } }

    public bool isPlaying;
    public float gameTime;

    public Sprite[] evalSprite;
    public SpriteRenderer evalDisplay;

    public InputID currentKey;
    public UnityEvent<InputID> keyPress;

    public HealthbarScript hpManager;

    public void KeyAddListener(UnityAction<InputID> action) {
        if (keyPress == null) {
            keyPress = new UnityEvent<InputID>();
        }

        keyPress.AddListener(action);
    }

    protected override void InputAction(InputID inputID) {
        base.InputAction(inputID);
        keyPress.Invoke(inputID);
        currentKey = inputID;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Forgive me Kevin and Sama
    public void NoteHit(float eval) {
        if (Mathf.Abs(eval) < .15) { evalDisplay.sprite = evalSprite[0]; }
        else if (Mathf.Abs(eval) < .35) { evalDisplay.sprite = evalSprite[1]; }
        else if (Mathf.Abs(eval) < .5) { evalDisplay.sprite = evalSprite[2]; }
        else { evalDisplay.sprite = evalSprite[3]; hpManager.AddDamage(100); }
    }

    public void NoteMiss() {
        evalDisplay.sprite = evalSprite[4];
        hpManager.AddDamage(250);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying) {
            gameTime += Time.deltaTime;
        }
    }
}
