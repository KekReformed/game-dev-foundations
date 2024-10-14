using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartScreenButtons : MonoBehaviour
{
    public void GoToScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
