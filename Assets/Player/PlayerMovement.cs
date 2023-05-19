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

    public bool IsRotatingCamera
    {
        get => _isRotatingCamera;
        set => _isRotatingCamera = value;
    }

    public void Movement(Vector2 input)
    {
        if (input == Vector2.zero) return;
        
        var input3D = new Vector3(input.x, playerRigidbody.velocity.y / speed, input.y);
        //playerRigidbody.velocity = input3D * speed;
        //playerRigidbody.MovePosition(transform.position + (input3D.normalized * speed * Time.deltaTime));
        var velocity = input3D * speed;
        playerRigidbody.velocity = transform.forward * velocity.z + transform.right * velocity.x;
        //transform.localPosition
        if(_isRotatingCamera) return;
        RotatePlayer(input);
        //MovementRotation(input);
    }

    private void RotatePlayer(Vector2 input)
    {
        /*
        var moveDirection = playerRigidbody.velocity - transform.position;
        var playerLookAtPosition = new Vector3(input.x, 0, input.y).normalized;
        var directionLookRotation = transform.rotation * playerLookAtPosition;
        var newRotation = Quaternion.LookRotation(directionLookRotation, transform.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.15f);
        */
        
        /*
        var moveDirection = playerRigidbody.velocity - transform.position;
        transform.rotation = Quaternion.LookRotation(moveDirection);
        */
        
        var moveDirection = transform.TransformDirection(Vector3.forward);
        transform.rotation = Quaternion.LookRotation(moveDirection);
        Debug.DrawRay(transform.position, moveDirection);
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
        var beginPosition = transform.rotation;
        var targetToRotate = cameraTransform.rotation;
        var rotateDirection = Quaternion.Lerp(beginPosition, targetToRotate, rotateSpeed * Time.deltaTime);
        rotateDirection.x = beginPosition.x;
        rotateDirection.z = beginPosition.z;
        transform.rotation = rotateDirection;
    }
}
