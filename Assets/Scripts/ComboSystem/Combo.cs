using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combo System/Combo")]
public class Combo : ScriptableObject {
    // Put varible for the combo in here as a array, so we can put as many combos as we want in here and in seperate combo dictionaries for each level

    public MoveState[] data;
}

[System.Serializable]
public struct MoveState {
    public MoveStateType type;

    [Header("Input Key")]
    [Tooltip("0-8: joystick, with 0=neutral, 1=right, 2=upright,\n3=up, 4 = upleft, 5 = left,\n6 = downleft, 7 = down, 8 = downright\n9: A\n10: B")]
    public InputID key;
    public InputID extraKey;

    [Space(10)]
    public float minDuration;
    public float maxDuration;

    public MoveState(MoveStateType type = MoveStateType.Single, InputID key = 0, InputID extraKey = 0, float min = 0.1f, float max = 1f) {
        this.type = type;
        this.key = key;
        this.extraKey = extraKey;
        this.minDuration = min;
        this.maxDuration = max;
    }

    public bool Equals(MoveState other) {
        return
            type == other.type &&
            key == other.key &&
            (type == other.type || extraKey == other.extraKey);
    }
}

public enum MoveStateType {
    Single,
    Double,
    Polyrhythm,
    Hold
}

