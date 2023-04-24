using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputParse : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputActionAsset _playerControlAction;

    [SerializeField] private PlayerMovement playerMovement;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerControlAction = _playerInput.actions;
    }
    void Update()
    {
        playerMovement.MovementPlayer(_playerControlAction["Movement"].ReadValue<Vector2>());
    }
}
