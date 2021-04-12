﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const string SceneName = "MainScene";
    private const string SceneName1 = "MenuScene";
    public static GameManager instance;
    public GameObject gameOverPanel;
    public Text scoreText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void GameOver()
    {
        ObstacleSpawner.instance.gameOver = true;
        StopScrolling();
        gameOverPanel.SetActive(true);
    }

    void StopScrolling()
    {
        TextureScroll[] scrollingObjects = FindObjectsOfType<TextureScroll>();

        foreach(TextureScroll item in scrollingObjects)
        {
            item.scroll = false;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Menu()
    {
        SceneManager.LoadScene(SceneName1);
    }

    public void IncrementScore()
    {
        int score = 0;
        score++;
        scoreText.text = score.ToString();
    }
}
