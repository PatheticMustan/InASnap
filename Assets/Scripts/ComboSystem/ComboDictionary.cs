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

public class MovementObject {

}

public struct MoveState {
    public MovementKey key;
    public float minDuration;
    public float maxDuration;

    public MoveState(MovementKey key = 0, float min = 0.1f, float max = 1f) {
        this.key = key;
        this.minDuration = min;
        this.maxDuration = max;
    }
}

/** Movement Key:
 * 0-8: joystick, with 0=neutral, 1=right, 2=upright, 3=up,
 *                  4=upleft, 5=left, 6=downleft, 7=down, 8=downright
 * 9: A
 * 10: B
 **/
public enum MovementKey {
    Neutral, Right, UpRight, Up, UpLeft, Left, DownLeft, Down, DownRight,
    A,
    B
}