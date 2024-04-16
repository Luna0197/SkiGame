using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;


public class Stopwatch : MonoBehaviour
{
    bool stopwatchActive = false;
    float currentTime;
    public Text currentTimeText;

    void Start()
    {
        StartStopwatch();
        currentTime = 0;
    }

    void Update()
    {
        if (stopwatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;

        }

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");   
    }

    public void StartStopwatch()
    {
        stopwatchActive = true;

    }

    public void StopStopwatch()
    {
        stopwatchActive = false;
    }

}