using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReciever : MonoBehaviour
{
    [SerializeField] public InputController controls;

    public Queue<InputID> inputQueue { protected get; set; }
    protected float timeBetweenActions;

    private void Awake()
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
        InputAction((InputID)(Mathf.Round(d) + (d >= 0 ? 1 : 0)));
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}

public enum InputID
{
    N = 0,
    L = 1,
    LU = 2,
    U = 3,
    RU = 4,
    R = 5,
    RD = -3,
    D = -2,
    LD = -1,

    A = 9,
    B = 10
}