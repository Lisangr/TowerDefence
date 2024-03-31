using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    public string Scene = "";
    public Slider slider;

    void Start()
    {
        StartCoroutine(LoadNextScene());    
    }

    private IEnumerator LoadNextScene()
    {
        AsyncOperation oper = SceneManager.LoadSceneAsync(Scene);

        while (!oper.isDone) 
        { 
            float progress = oper.progress/0.9f;
            slider.value = progress;
            yield return null;
        }
    }
}
