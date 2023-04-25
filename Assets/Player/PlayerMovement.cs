using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    
    private Vector3 _direction;

    public void MovementPlayer(Vector2 input)
    {
        var input3D = new Vector3(input.x, rigidbody.velocity.y / speed, input.y);
        rigidbody.velocity = input3D * speed;
        if (input != Vector2.zero)
        { 
            var rotateTarget = new Vector3(input.x, 0, input.y);
            var rotateDirection = Vector3.RotateTowards(transform.forward, rotateTarget, rotateSpeed * Time.deltaTime, 1);
            transform.rotation = Quaternion.LookRotation(rotateDirection); 
        }
    }
}
