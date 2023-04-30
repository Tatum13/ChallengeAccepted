using UnityEngine;
using UnityEngine.InputSystem;

public class InputParse : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private CameraController cameraController;
    
    private PlayerInput _playerInput;
    private InputActionAsset _playerControlAction;
    private Vector2 _mouseposition = new Vector2(0,0);
    
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerControlAction = _playerInput.actions;
    }
    
    private void Update()
    {
        var inputMovement = _playerControlAction["Movement"].ReadValue<Vector2>();
        playerMovement.MovementPlayer(inputMovement);

        var inputCamera = _playerControlAction["MouseClick"].ReadValue<float>();
        if (inputCamera == 1) return;
        //_playerControlAction["MouseLook"].;
        cameraController.MoveCamera();
    }
}
