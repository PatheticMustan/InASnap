using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Combos")]
public class Combo : ScriptableObject {
    // Put varible for the combo in here as a array, so we can put as many combos as we want in here and in seperate combo dictionaries for each level

    public MoveState[] data;
}

public class ComboObject {

}

[System.Serializable]
public class MovementObject {

}

[System.Serializable]
public struct MoveState {
    [Header("Input Key")]
    [Tooltip("0-8: joystick, with 0=neutral, 1=right, 2=upright,\n3=up, 4 = upleft, 5 = left,\n6 = downleft, 7 = down, 8 = downright\n9: A\n10: B")]
    public InputID key;

    [Space(10)]
    public float minDuration;
    public float maxDuration;

    public MoveState(InputID key = 0, float min = 0.1f, float max = 1f) {
        this.key = key;
        this.minDuration = min;
        this.maxDuration = max;
    }
}

