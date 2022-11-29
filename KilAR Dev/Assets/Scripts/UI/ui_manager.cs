using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ui_manager : MonoBehaviour
{
    public TMP_Text Score_text;
    //public TMP_Text level_name;
    public TMP_Text Count_down;
    public TMP_Text Ammo_Display;
    private TMP_Text Coin_Text;

    public GameObject Shoot_Text;
    public GameObject Reload_Text;
    public GameObject Disclaimer;
    public GameObject upgradeSystem;
    
    public int score;
    public int coin;
    
    
    private void Start()
    {
        Ammo_Display = GameObject.FindGameObjectWithTag("AmmoCount").GetComponent<TMP_Text>();
        Coin_Text = GameObject.FindGameObjectWithTag("Coin_Text").GetComponent<TMP_Text>();
        
        upgradeSystem = GameObject.FindGameObjectWithTag("UpgradeSystem");
        upgradeSystem.SetActive(false);
    }

    public void CoinRefresh(int coinCount)
    {
        Coin_Text.text = coinCount.ToString();
    }

    public void Refresh(int ammoCount)
    {
        Ammo_Display.text = ammoCount.ToString();
    }

    public void ScoreRefresh(int scoreCount)
    {
        Variables_Controller.score = scoreCount.ToString();
        Score_text.text = scoreCount.ToString();

        if(score > PlayerPrefs.GetInt("HighScore",0)){
            PlayerPrefs.SetInt("HighScore", score);
            //GOver.Score_GameEnd_Text.text = scoreCount.ToString();
        }
    }

    public void CountDown(float countDown)
    {
        Count_down.text = countDown.ToString("0");
    }

    //public void LevelName(string levelName)
    //{
    //    level_name.text = levelName;
    //}
}
