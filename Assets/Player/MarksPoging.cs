using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarksPoging : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private Rigidbody myRigidbody;
    
    public void MovePlayer(Vector3 input)
    {
        var velocity = input * maxSpeed;
        myRigidbody.velocity = velocity;
        //var rotationChange = newCameraRotation - Camera.main.transform.rotation;
        //var newVelocity = velocity * rotationChange;
        //myRigidbody.velocity = newVelocity;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity), 0.15f);
    }
}
