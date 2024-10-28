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
                SceneManager.LoadScene("StartScreen");
            }
            timerText.text = currentTime.ToString("f0");
        }
    }
    
    void TimerStart()
    {
        timerStarted = true;
    }
}
