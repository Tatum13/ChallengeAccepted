using UnityEngine;
using UnityEngine.InputSystem;

public class InputParse : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    
    private PlayerInput _playerInput;
    private InputActionAsset _playerControlAction;
    
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerControlAction = _playerInput.actions;
    }
    
    private void Update()
    {
        var inputMovement = _playerControlAction["Movement"].ReadValue<Vector2>();
        playerMovement.MovementPlayer(inputMovement);
    }
}
