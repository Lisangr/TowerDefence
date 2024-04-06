using UnityEngine;

public class StopCutScene : MonoBehaviour
{
    public delegate void PressAction();
    public static event PressAction OnCutSceneSkipped;

    public GameObject cutSceneObject;
    public GameObject buttonTower;

    public void CloseCutScene()
    {
        cutSceneObject.SetActive(false);
        OnCutSceneSkipped?.Invoke();

        buttonTower.SetActive(true);
    }
    
}
