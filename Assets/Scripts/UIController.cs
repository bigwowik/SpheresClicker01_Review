using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("Some Menu Objects")]
    public GameObject gameUI;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    private bool wasEnabled;

    private void Start()
    {
        wasEnabled = false;

        Pause();

        ScoreManager.DeathEvent += GameOver;
    }

    private void OnDisable()
    {
        ScoreManager.DeathEvent -= GameOver;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (!wasEnabled)
        {
            wasEnabled = true;
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            gameUI.SetActive(false);
        }
        else
        {
            wasEnabled = false;
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            gameUI.SetActive(true);
        }
    }
    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
