using UnityEngine;
using Cinemachine;
//��� ������ ������ �� ����� ������ �������� https://www.youtube.com/watch?v=zVPipdvXh5E
//� ������ ������ ������. ����� ����� ��� ������������ ����� �������� ��� ����� ������ � ����� 
//��� ����������� � ��������� ��� ��������
public class CameraChanger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] cameras;
    private int currentCameraIndex;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))// Input.GetBitton("Jump") � ���� �������� ����� ������
            SwitchCamera();
    }
    void SwitchCamera()
    {
        //cameras[currentCameraIndex].gameObject.SetActive(false);
        cameras[currentCameraIndex].Priority = 0;//������� ������
        currentCameraIndex++;

        if (currentCameraIndex >= cameras.Length)        
            currentCameraIndex = 0;

        //cameras[currentCameraIndex].gameObject.SetActive(true);
        cameras[currentCameraIndex].Priority = 1;//��, ���� ������������� ������
    }
}
