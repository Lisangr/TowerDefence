using UnityEngine;
using Cinemachine;
public class CameraChanger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] cameras;
    private int currentCameraIndex;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))// Input.GetButton("Jump")
            SwitchCamera();
    }
    void SwitchCamera()
    {

        cameras[currentCameraIndex].Priority = 0;
        currentCameraIndex++;

        if (currentCameraIndex >= cameras.Length)        
            currentCameraIndex = 0;

        cameras[currentCameraIndex].Priority = 1;
    }
}
