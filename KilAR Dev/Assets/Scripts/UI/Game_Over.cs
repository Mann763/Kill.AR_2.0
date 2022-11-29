using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour
{
    public TMP_Text High_Score;
    public TMP_Text Score;


    // Start is called before the first frame update
    void Start()
    {
        High_Score.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        Score.text = Variables_Controller.score;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void Back()
    {
        SceneManager.LoadScene(1);
    }
}
