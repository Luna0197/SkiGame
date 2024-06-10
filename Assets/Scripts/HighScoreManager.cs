using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class HighScoreManager : MonoBehaviour
{

    public Stopwatch stopwatch;
    public float Highscore;
    public GameObject winScreen;
    public GameObject objectWithScript;

    List<string> times = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highscore();
    }

    public void highscore()
    {
       if (winScreen.activeSelf)
        {
            Debug.Log(Stopwatch.currentTime);
        }
    }
}
