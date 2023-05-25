using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private Transform cineMachineCamera;
    
    public void MovePlayer(Vector3 input)
    {
        var velocity = input * maxSpeed;
        myRigidbody.velocity = velocity;
        //var targetRotation = 
        //var rotateLocation = targetRotation - cineMachineCamera.rotation;
        //var newRotation = velocity * rotateLocation;
        //Quaternion.Angle(cineMachineCamera.rotation, cineMachineCamera.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity), 0.15f);
    }
}
