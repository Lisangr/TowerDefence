using UnityEngine;
using Cinemachine;
//сам скрипт вешаем на любой объект источник https://www.youtube.com/watch?v=zVPipdvXh5E
//в массив кидаем камеры. Метод нужен для переключения камер например для точек обзора с башни 
//или приблежения к персонажу для торговли
public class CameraChanger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] cameras;
    private int currentCameraIndex;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))// Input.GetBitton("Jump") и иные варианты смены камеры
            SwitchCamera();
    }
    void SwitchCamera()
    {
        //cameras[currentCameraIndex].gameObject.SetActive(false);
        cameras[currentCameraIndex].Priority = 0;//текущая камера
        currentCameraIndex++;

        if (currentCameraIndex >= cameras.Length)        
            currentCameraIndex = 0;

        //cameras[currentCameraIndex].gameObject.SetActive(true);
        cameras[currentCameraIndex].Priority = 1;//та, куда переключились камера
    }
}
