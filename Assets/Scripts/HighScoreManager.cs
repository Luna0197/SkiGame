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

            // Check if the new time is faster than any existing time
            bool isNewBestTime = scoresList.Count < 10 || newTime < scoresList[scoresList.Count - 1];

            if (isNewBestTime)
            {
                // Add the new time to the scores list
                scoresList.Add(newTime);

                // Sort the scores list
                scoresList.Sort();

                // Keep only the top 10 scores
                if (scoresList.Count > 10)
                {
                    scoresList.RemoveAt(scoresList.Count - 1);
                }

                // Save scores to PlayerPrefs
                SaveScores();

                // Update the UI Text object with the list of scores
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
        // Convert the sorted list of scores to a string and save it to PlayerPrefs
        string scoresString = string.Join(",", scoresList.Select(s => s.ToString()).ToArray());
        PlayerPrefs.SetString("Scores", scoresString);
        PlayerPrefs.Save();
    }

    void LoadScores()
    {
        // Load scores from PlayerPrefs and convert them back to a list
        string scoresString = PlayerPrefs.GetString("Scores");
        if (!string.IsNullOrEmpty(scoresString))
        {
            string[] scoresArray = scoresString.Split(',');
            scoresList = scoresArray.Select(float.Parse).ToList();

            // Sort the scores list
            scoresList.Sort();

            // Update the UI Text object with the list of scores
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        // Format the list of scores for display
        string scoresText = "High Scores:\n";
        for (int i = 0; i < scoresList.Count; i++)
        {
            scoresText += $"{i + 1}. {scoresList[i]:F2}\n"; // Format score with two decimal places
        }

        // Update the text of the UI Text object
        scoreText.text = scoresText;
    }
}
