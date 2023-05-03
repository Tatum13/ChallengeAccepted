using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook cinemachineFreeLook;
    [SerializeField] private float cameraXSpeed;
    [SerializeField] private float cameraYSpeed;

    public void MoveCamera(float inputCamera)
    {
        if (inputCamera == 1)
        {
            cinemachineFreeLook.m_XAxis.m_MaxSpeed = cameraXSpeed;
            cinemachineFreeLook.m_YAxis.m_MaxSpeed = cameraYSpeed;
        }
        else
        {
            cinemachineFreeLook.m_XAxis.m_MaxSpeed = 0;
            cinemachineFreeLook.m_YAxis.m_MaxSpeed = 0;
        }
    }
}
