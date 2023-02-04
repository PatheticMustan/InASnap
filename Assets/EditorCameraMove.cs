using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorCameraMove : MonoBehaviour
{
    private Camera mainCamera;

    private bool isDrag;
    private Vector3 origin;
    private Vector3 mousePos;
    private Vector3 difference;

    private InputController controls;

    void Awake() {
        mainCamera = Camera.main;

        controls = new InputController();

        controls.Editor.PressRight.performed += _ => ActivateMove(true);
        controls.Editor.HoldRight.canceled += _ => ActivateMove(false);
        controls.Editor.MousePos.performed += pos => MoveCamera(pos.ReadValue<Vector2>());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ActivateMove(bool flag) {
        isDrag = flag;
        if (flag)
            origin = mousePos;
    }

    public void MoveCamera(Vector2 pos) {
        mousePos = mainCamera.ScreenToWorldPoint(pos);

        if (isDrag) {
            difference = origin - mousePos + mainCamera.transform.position;

            mainCamera.transform.position = new Vector3(difference.x, 0, -10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
