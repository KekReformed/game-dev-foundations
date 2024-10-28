using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused;
    public CharacterController controller;
    public GameObject PausePanel;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Paused Pressed");
            gameIsPaused = !gameIsPaused;
            PauseGame();       
        }

        if (Input.GetKeyDown(KeyCode.Comma))
        {
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
        }

    }
    public void PauseGame()
    {
        if (gameIsPaused == true)
        {
            Debug.Log("Paused");
            PausePanel.SetActive(true);
            controller.enabled = false;
            Time.timeScale = 0;
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Unpaused");
            PausePanel.SetActive(false);
            controller.enabled = true;
            Time.timeScale = 1;
            Camera.main.gameObject.SetActive(false);
        }
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}