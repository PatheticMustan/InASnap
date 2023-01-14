using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReciever : MonoBehaviour
{
    [SerializeField] protected InputController controls;

    public Queue<InputID> inputQueue { protected get; set; }
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
        Debug.Log(inputID);
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
        //Convert to angles of 45 degree intervals
        float d = Mathf.Atan2(dir.y, dir.x) * 1.27323f;

        //Convert to proper enum value
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

public enum InputID
{
    N = 0,
    R = 1,
    RU = 2,
    U = 3,
    LU = 4,
    L = 5,
    LD = 6,
    D = 7,
    RD = 8,

    A = 9,
    B = 10
}