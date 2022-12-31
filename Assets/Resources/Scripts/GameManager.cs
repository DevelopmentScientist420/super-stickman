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

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void DamagePlayer(int damageValue)
    {
        playerHealthSlider.value = GameData.PlayerHealth -= damageValue;
    }

    public void PlayerDie()
    {
        GameData.PlayerHealth = 0;
        GameData.IsWin = false;
        ChangeScene("StatScene");
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void ResetData()
    {
        GameData.PlayerHealth = 30;
        GameData.BulletAmmo = 5;
        GameData.PlayerScore = 0;
    }

    private void CheckOrAddHighScore()
    {
        var scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        //If never initialized before, high score will be set to the default value of 0
        //And if player score is higher than the high score, then it will update itself
        //High score will be saved and updated locally in the player's computer so that when the game restarts
        //the high score value is never lost
        if (GameData.PlayerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", GameData.PlayerScore);
        }
        scoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "FirstLevel")
        {
            //Sets player health slider and its values
            playerHealthSlider = GameObject.Find("Player").GetComponentInChildren<Slider>();
            playerHealthSlider.maxValue = GameData.PlayerHealth;
            playerHealthSlider.value = GameData.PlayerHealth;
            
            //Resets static variable data
            ResetData();
        } else if (scene.name == "ScoreScene")
        {
            if (this != Instance) return;
            CheckOrAddHighScore();
        }
        else if (scene.name == "StatScene") 
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
