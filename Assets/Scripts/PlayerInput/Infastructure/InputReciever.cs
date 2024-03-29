﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReciever : MonoBehaviour
{
    protected InputController controls;

    protected float timeBetweenActions;

    protected virtual void Awake()
    {
        controls = new InputController();

        controls.Player.APress.performed += _ => APress();
        controls.Player.BPress.performed += _ => BPress();
        controls.Player.Direction.performed += dir => Direction(dir.ReadValue<Vector2>());
    }

    protected virtual void InputAction(InputID inputID)
    {
        //Debug.Log(inputID);
    }

    protected virtual void APress()
    {
        InputAction(InputID.A);
    }

    protected virtual void BPress()
    {
        InputAction(InputID.B);
    }

    protected virtual void Direction(Vector2 dir)
    {
        // Convert to angles of 45 degree intervals
        // (180/pi)/45 = 1.27323
        float d = Mathf.Atan2(dir.y, dir.x) * 1.27323f;

        // Convert to proper enum value
        InputAction((InputID)(Mathf.Round(d) + (d >= 0 ? 1 : 9)));
    }

    protected virtual void OnEnable()
    {
        controls.Enable();
    }

    protected virtual void OnDisable()
    {
        controls.Disable();
    }
}

/** Movement Key:
 * 0-8: joystick, with 0=neutral, 1=right, 2=upright, 3=up,
 *                  4=upleft, 5=left, 6=downleft, 7=down, 8=downright
 * 9: A
 * 10: B
 **/
public enum InputID {
    Neutral = 0, Right = 1, Rightup = 2, Up = 3, Leftup= 4, Left = 5, Leftdown = 6, Down = 7, Rightdown = 8,
    A = 9,
    B = 10
}