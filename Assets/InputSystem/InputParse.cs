using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputParse : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CameraController cameraController;

    [SerializeField] private float rotateSpeed;

    private PlayerInput _playerInput;
    private InputActionAsset _playerControlAction;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerControlAction = _playerInput.actions;
    }
    private void FixedUpdate()
    {
        var inputMovement = _playerControlAction["Movement"].ReadValue<Vector2>();
        playerMovement.Movement(inputMovement);

        var inputCamera = _playerControlAction["MouseClick"].ReadValue<float>();
        cameraController.MoveCamera(inputCamera);
        if (inputCamera == 1f) playerMovement.LookAtDirection();
        else playerMovement.IsRotatingCamera = false;
    }
}
