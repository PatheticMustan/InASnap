using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReciever : MonoBehaviour
{
    [SerializeField] protected InputController controls;
    //[SerializeField] protected ComboDictionary combos;

    public Queue<InputID> inputQueue { protected get; set; }
    protected float timeBetweenActions;

    private void Awake()
    {
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
        InputAction((InputID)(Mathf.Round(Mathf.Atan2(dir.y, dir.x) / 0.7853f) + 1));
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
    RD = 6,
    D = 7,
    LD = 8,
    A = 9,
    B = 10
}