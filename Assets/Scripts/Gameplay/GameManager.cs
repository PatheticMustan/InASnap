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

    public InputID currentKey;
    public UnityEvent<InputID> keyPress;

    protected override void InputAction(InputID inputID) {
        base.InputAction(inputID);
        keyPress.Invoke(inputID);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
