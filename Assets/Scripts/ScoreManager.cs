using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    [Header("Start")]
    public int startHealth = 10;
    [Header("Texts UI")]
    public TMPro.TMP_Text[] scoreTexts;
    public TMPro.TMP_Text healthText;
    public TMPro.TMP_Text[] maxScoreTexts;
    

    public static ScoreManager Instance;
    public static Action DeathEvent;

    //private
    private int scoreValue;
    private int healthValue;
    private int maxScore;

    private void Awake() 
    {
        Instance = this; //little singleton
        healthValue = startHealth;

        maxScore = PlayerPrefs.GetInt("MaxScore", 0);

        UpdateScore();
        UpgradeHealth(); 
        UpdateMaxScore();
    }


    void UpdateScore()
    {
        Array.ForEach(scoreTexts, item => item.text = "Score: " + scoreValue);
        
    }
    void UpgradeHealth()
    {
        healthText.text = "Health: " + healthValue;

        
    }

    


    void UpdateMaxScore()
    {
        Array.ForEach(maxScoreTexts, item => item.text = "Max score: " + maxScore);
    }



    public void UpScore(int addScoreValue)
    {
        scoreValue += addScoreValue;
        UpdateScore();
    }

    public void TakeDamage(int damageValue)
    {
        if (healthValue - damageValue <= 0)
        {
            healthValue = 0;
            Death();
        }
        else 
            healthValue -= damageValue;

        UpgradeHealth();
        SetRedColor();

    }
    void SetRedColor()
    {
        healthText.color = Color.red;
        Invoke("SetWhiteColor", 0.3f);
    }
    void SetWhiteColor()
    {
        healthText.color = Color.black;
    }



    void Death()
    {
        var newMaxScore = scoreValue;

        var lastMaxScore = PlayerPrefs.GetInt("MaxScore", 0);
        if (newMaxScore > lastMaxScore)
        {
            maxScore = newMaxScore;
            PlayerPrefs.SetInt("MaxScore", maxScore);
        }

        UpdateMaxScore();

        Debug.Log("YOU DIED");
        DeathEvent?.Invoke();
    }

    public void ResetMaxScore()
    {
        PlayerPrefs.DeleteKey("MaxScore");
        Debug.Log("Max score was reseted.");

        maxScore = 0;
        UpdateMaxScore();
    }
}
