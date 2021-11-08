using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text healthText;

    public int startHealth = 10;

    public int scoreValue;
    public int healthValue;

    public static Score Instance;
    private void Awake() 
    {
        Instance = this; //little singleton
        healthValue = startHealth;

        UpdateScore();
        UpgradeHealth();
    }


    void UpdateScore()
    {
        scoreText.text = "Score: " + scoreValue;
    }
    void UpgradeHealth()
    {
        healthText.text = "Health: " + healthValue;
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

    }

    void Death()
    {
        Debug.Log("YOU DIED");
    }
}
