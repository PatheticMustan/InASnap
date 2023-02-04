using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboReader : InputReciever
{
    public ComboList comboList;

    public Queue<InputID> inputQueue { protected get; set; }

    // Start is called before the first frame update
    protected new void Awake() {
        inputQueue = new Queue<InputID>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void FixedUpdate() {
        //Also can check here

        //Pop the queue if
        //Invalid Combo
        //Time between inputs is too long
        //Sucessful Combo
    }

    protected override void InputAction(InputID inputID) {
        base.InputAction(inputID);
        inputQueue.Enqueue(inputID);
        //Add to Queue and Check combo things here?
    }
}
