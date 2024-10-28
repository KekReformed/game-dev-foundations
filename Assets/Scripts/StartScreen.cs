using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public Camera StartCamera;
    public Camera OptionsCamera;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Options()
    {
       
    }
    public void BackOptions()
    {
       Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSdFfG1cVGgsqo3wc2KUr7FlQ3ZlpJfkWB4UuJYxD2NyS6VNTA/viewform?usp=sf_link");
    }
    public void QuitGame()
    {
        //Application.Quit;
    }
}
