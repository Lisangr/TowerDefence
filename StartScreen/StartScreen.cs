using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public string Scene = "";

    public void onClickStart()
    {
        SceneManager.LoadScene(Scene, LoadSceneMode.Single);
    }
}
