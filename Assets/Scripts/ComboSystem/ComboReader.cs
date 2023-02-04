using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboReader : InputReciever {
    public ComboList comboList;
    public List<TInput> tony { protected get; set; }
    public int maxCoumboLength;

    protected new void Awake() {
        base.Awake();
        tony = new List<TInput>();
    }

    private void FixedUpdate() {
        // if the player is inactive for a certain period, revert to neutral animation
        // clear queue
    }



    protected override void InputAction(InputID inputID) {
        base.InputAction(inputID);

        // shave off whatever extra we have, add the new input
        if (tony.Count >= maxCoumboLength) {
            tony.RemoveRange(0, maxCoumboLength - tony.Count + 1);
        }
        tony.Add(new TInput(inputID, Time.timeSinceLevelLoad));

        // loop through each combo, check
        for (int i = 0; i < comboList.list.Length; i++) {
            MoveState[] requiredInputs = comboList.list[i].data;

            // verify inputs in reverse order
            for (int o = requiredInputs.Length - 1; o >= 0; o--) {

            }
        }
    }
}

public struct TInput {
    public InputID inputID;
    public float timestamp;

    public TInput(InputID inputID, float timestamp) {
        this.timestamp = timestamp;
        this.inputID = inputID;
    }
}