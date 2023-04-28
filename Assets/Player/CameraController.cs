using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float xRotateCamera;
    [SerializeField] private float yRotateCamera = 90f;

    private float _mouseX;
    private float _mouseY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MouseMovement(InputControls.InputsActions input)
    {
        /*
        _mouseX = input * mouseSensitivity * Time.deltaTime;
        _mouseY = input * mouseSensitivity * Time.deltaTime;
        */
        xRotateCamera -= _mouseY;
    }
    
    public void Test(InputControls.InputsActions input){}
}
