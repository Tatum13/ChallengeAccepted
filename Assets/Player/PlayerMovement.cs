using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Transform cameraTransform;

    [SerializeField] private bool _isRotatingCamera;

    private Vector2 _oldInput;
    private Vector3 _directionLookRotation;

    public bool IsRotatingCamera
    {
        get => _isRotatingCamera;
        set => _isRotatingCamera = value;
    }

    public void Movement(Vector2 input)
    {
        
        var input3D = new Vector3(input.x, 0, input.y);
        var velocity = input3D * speed;
        playerRigidbody.velocity = velocity;
        if(_isRotatingCamera) return;
        RotatePlayer(input);
    }

    public void LookAtDirection()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerRigidbody.velocity), 0.15f);
    }
    
    private void RotatePlayer(Vector2 input)
    {
        if (_oldInput != input)
        {
            var playerLookAtPosition = new Vector3(input.x, 0, 0).normalized;
            _directionLookRotation = playerRigidbody.gameObject.transform.rotation * playerLookAtPosition;
        }

        //var moveDirection = playerRigidbody.velocity - transform.position;
        var newRotation = Quaternion.LookRotation(_directionLookRotation, transform.up);
        playerRigidbody.gameObject.transform.rotation = Quaternion.Slerp(playerRigidbody.gameObject.transform.rotation, newRotation, 0.15f);
        
        _oldInput = input;
        
        /*
        var playerLookAtPosition = new Vector3(input.x, 0, input.y).normalized;
        var directionLookRotation = transform.rotation * playerLookAtPosition;
        var newRotation = Quaternion.LookRotation(directionLookRotation, transform.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.15f);
        */
        //Debug.Log(input);
        /*
        var moveDirection = playerRigidbody.velocity - transform.position;
        transform.rotation = Quaternion.Loo kRotation(moveDirection);
        */
        
        /*
        var moveDirection = transform.TransformDirection(Vector3.forward);
        transform.rotation = Quaternion.LookRotation(moveDirection);
        Debug.DrawRay(transform.position, moveDirection);
        */
    }

    private void MovementRotation(Vector2 input)
    {
        var rotateTarget = new Vector3(input.x, 0, input.y);
        var rotateDirection = Vector3.RotateTowards(transform.position, rotateTarget, rotateSpeed * Time.deltaTime, 1);
        transform.rotation = Quaternion.LookRotation(rotateDirection);
    }

    public void TurnToCameraDirection()
    {
        _isRotatingCamera = true;
        var beginPosition = playerRigidbody.gameObject.transform.rotation;
        var targetToRotate = cameraTransform.rotation;
        var rotateDirection = Quaternion.Lerp(beginPosition, targetToRotate, rotateSpeed * Time.deltaTime);
        rotateDirection.x = beginPosition.x;
        rotateDirection.z = beginPosition.z;
        playerRigidbody.gameObject.transform.rotation = rotateDirection;
    }
}
