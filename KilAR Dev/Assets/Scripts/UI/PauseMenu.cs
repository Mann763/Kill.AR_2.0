using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject gamePaused;
    public GameObject back;
    public GameObject settings;
    public GameObject exit;
    public GameObject pause;
    public GameObject privacy;

    public void Pause()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }

        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            Debug.Log("Resumed");
        }

        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        pause.SetActive(true);
        gamePaused.SetActive(true);
        back.SetActive(true);
        settings.SetActive(true);
        exit.SetActive(true);
        pause.SetActive(true);
    }

    public void Settings()
    {
        gamePaused.SetActive(false);
        back.SetActive(false);
        settings.SetActive(false);
        exit.SetActive(false);
        pause.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void Exit()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);
        }
        
    }

    public void Privacy()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
    }
}
