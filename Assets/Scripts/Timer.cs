using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //Start time value
    [SerializeField] float startTime;

    //Current Time
    float currentTime;

    //Has timer started
    bool timerStarted;

    [SerializeField] string sceneToLoad;

    //ref var for TMPro text
    [SerializeField] TMP_Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        timerText.text = currentTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            timerStarted = true;
        }
        if (timerStarted)
        {
            //subtracting timer durtation 
            currentTime -= Time.deltaTime;
            //logic if time reach 0
            if (currentTime <= 0)
            {
                Debug.Log("Timer Reached Zero");
                timerStarted = false;
                currentTime = 0;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(sceneToLoad);
            }
            timerText.text = currentTime.ToString("f0");
        }
    }
    //command for the timer
     void TimerStart()
    {
        timerStarted = true;
    }
}
