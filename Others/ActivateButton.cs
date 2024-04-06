using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    private int sceneSkipped = 0;
    public GameObject buttonTower;
    private void Awake()
    {
        StopCutScene.OnCutSceneSkipped += IncrementSceneSkipped;
    }

    private void IncrementSceneSkipped()
    {
        sceneSkipped += 1;
    }

    private void Update()
    {
        if (sceneSkipped > 0)
        {
            buttonTower.SetActive(true);
        }
    }
}
