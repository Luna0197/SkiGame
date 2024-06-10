using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    
    public void paused()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void home()
    {
        SceneManager.LoadScene("mainMenu");
        Time.timeScale = 1;
    }
}
