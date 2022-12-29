using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private Slider playerHealthSlider;
    private int score = 0;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        GameData.PlayerScore = score;
    }

    public void DamagePlayer(int damageValue)
    {
        playerHealthSlider.value = GameData.PlayerHealth -= damageValue;
    }

    public void PlayerDie()
    {
        GameData.PlayerHealth = 0;
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "FirstLevel")
        {
            playerHealthSlider = GameObject.Find("Player").GetComponentInChildren<Slider>();
            playerHealthSlider.maxValue = GameData.PlayerHealth;
            playerHealthSlider.value = GameData.PlayerHealth;
        } else if (scene.name == "StatScene")
        {
            var statText = GameObject.Find("StatText").GetComponent<TextMeshProUGUI>();
            var scoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
            if (!GameData.IsWin)
            {
                statText.text = "You Lost!";
                scoreText.text = $"Score: {GameData.PlayerScore}";
            } else if (GameData.IsWin)
            {
                statText.text = "You Win!";
                scoreText.text = $"Score: {GameData.PlayerScore}";
            }
        }
    }
}
