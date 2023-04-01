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
        for (int i = 0; i < maxCoumboLength; i++) {
            tony.Add(new TInput(InputID.Neutral, 0));
        }
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
            //Debug.Log("checking " + comboList.list[i].name + "...");
            if (CheckCombo(i)) {
                ComboPostscript(i);
            }
        }
    }

    private bool CheckCombo(int comboIndex) {
        MoveState[] requiredInputs = comboList.list[comboIndex].data;

        // verify inputs in reverse order
        int currentInputIndex = tony.Count - 1;

        for (int i = requiredInputs.Length - 1; i >= 0; i--) {
            // check if it's included in one of the buffer moves
            if (requiredInputs[i].bufferMoves.Contains(tony[currentInputIndex].inputID)) {
                // buffer move, keep i the same but decrement currentInputID
                if (currentInputIndex > 1) {
                    currentInputIndex--;
                    i++;
                    continue;
                } else {
                    // we've reached the end of tony... sorry tony
                    return false;
                }
            }




            if (requiredInputs[i].key != tony[currentInputIndex].inputID) {
                // the combo is invalid, continue on to the next one
                return false;
            }

            // check for valid time window


            // check for invalid index
            currentInputIndex--;
            if (currentInputIndex < 0) {
                Debug.Log("thrown early");
                return false;
            }
        }

        return true;
    }

    private void ComboPostscript(int index) {
        Debug.Log("valid combo! " + comboList.list[index].name + " " + index);
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