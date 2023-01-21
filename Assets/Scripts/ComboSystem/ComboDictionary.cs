using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Combo Dictionary")]
public class ComboDictionary : ScriptableObject {
    // Put varible for the combo in here as a array, so we can put as many combos as we want in here and in seperate combo dictionaries for each level
    
    public MovementObject[] data;
}

public class ComboObject {

}

[System.Serializable]
public class MovementObject {

}

public struct MoveState {
    public InputID key;
    public float minDuration;
    public float maxDuration;

    public MoveState(InputID key = 0, float min = 0.1f, float max = 1f) {
        this.key = key;
        this.minDuration = min;
        this.maxDuration = max;
    }
}