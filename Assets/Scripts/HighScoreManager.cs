using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public Stopwatch stopwatch;
    public List<float> scoresList = new List<float>();
    public GameObject winObject;
    private bool scorePrinted = false;

    public Text scoreText; // Reference to the UI Text object

    void Update()
    {
        checkWin();
    }

    void Awake()
    {
        stopwatch = FindObjectOfType<Stopwatch>();

        // Load scores from PlayerPrefs when the game starts
        LoadScores();
    }

    void checkWin()
    {
        if (winObject.activeSelf && !scorePrinted)
        {
            GetScore();
            scorePrinted = true;
            float newTime = stopwatch.currentTime;

            bool isNewBestTime = scoresList.Count < 10 || newTime < scoresList[scoresList.Count - 1];

            if (isNewBestTime)
            {
                
                scoresList.Add(newTime);
                scoresList.Sort();
                if (scoresList.Count > 10)
                {
                    scoresList.RemoveAt(scoresList.Count - 1);
                }

                
                SaveScores();
                UpdateScoreText();
            }
        }
    }

    void GetScore()
    {
        Debug.Log(stopwatch.currentTime);
    }

    void SaveScores()
    {
        string scoresString = string.Join(",", scoresList.Select(s => s.ToString()).ToArray());
        PlayerPrefs.SetString("Scores", scoresString);
        PlayerPrefs.Save();
    }

    void LoadScores()
    {
        string scoresString = PlayerPrefs.GetString("Scores");
        if (!string.IsNullOrEmpty(scoresString))
        {
            string[] scoresArray = scoresString.Split(',');
            scoresList = scoresArray.Select(float.Parse).ToList();
            scoresList.Sort();
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        string scoresText = "High Scores:\n";
        for (int i = 0; i < scoresList.Count; i++)
        {
            scoresText += $"{i + 1}. {scoresList[i]:F2}\n"; 
        }

        scoreText.text = scoresText;
    }
}
