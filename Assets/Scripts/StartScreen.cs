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
        SceneManager.LoadScene("SampleScene");
    }
    public void Options()
    {
       
    }
    public void BackOptions()
    {
        StartCamera.enabled = true;
        OptionsCamera.enabled = false;
    }
    public void QuitGame()
    {
        //Application.Quit;
    }
}