using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook cinemachineFreeLook;
    [SerializeField] private Vector2 cameraMaxSpeed;

    public void MoveCamera(float inputCamera)
    {
        var mouseButtonIsPressed = 1 == Mathf.RoundToInt(inputCamera);
        
        cinemachineFreeLook.m_XAxis.m_MaxSpeed = mouseButtonIsPressed ? cameraMaxSpeed.x : 0;
        cinemachineFreeLook.m_YAxis.m_MaxSpeed = mouseButtonIsPressed ? cameraMaxSpeed.y : 0;
    }
}
