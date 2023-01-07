using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReciever : MonoBehaviour
{
    public InputMaster controls;

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
