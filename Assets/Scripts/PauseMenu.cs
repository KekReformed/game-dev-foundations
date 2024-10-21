using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }
    public void PauseGame()
    {
        if (gameIsPaused == true)
        {
            Debug.Log("Paused");
            PausePanel.SetActive(true);
            controller.enabled = false;
            Time.timeScale = 0;
        }
        else
        {
            Debug.Log("Unpaused");
            PausePanel.SetActive(false);
            controller.enabled = true;
            Time.timeScale = 1;
        }
    }
}