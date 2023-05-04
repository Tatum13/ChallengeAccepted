using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    
    public void MovementPlayer(Vector2 input)
    {
        if (input == Vector2.zero) return;
        
        var input3D = new Vector3(input.x, playerRigidbody.velocity.y / speed, input.y);
        playerRigidbody.velocity = input3D * speed;
        
        var rotateTarget = new Vector3(input.x, 0, input.y);
        var rotateDirection = Vector3.RotateTowards(transform.forward, rotateTarget, rotateSpeed * Time.deltaTime, 1);
        transform.rotation = Quaternion.LookRotation(rotateDirection);
    }
}
