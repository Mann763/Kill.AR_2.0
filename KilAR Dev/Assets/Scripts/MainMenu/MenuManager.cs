using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject settingsPanel;
    
    public void play()
    {
        SceneManager.LoadScene(2);
    }

    public void exit()
    {
        Debug.Log("QUIT GAME!!");
        Application.Quit();
    }

    public void settings()
    {
        settingsPanel.SetActive(true);
    }

    public void back()
    {
        settingsPanel.SetActive(false);
    }

    public void privacy()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        Debug.Log("is this working?");
    }

    public void Credits()
    {
        SceneManager.LoadScene(5);
    }

}
