using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.InputSystem.HID;

public class GameManager : Singleton<GameManager>
{
    private Slider playerHealthSlider;
    private SaveLoadManager saveLoadManager;

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
        GameManager.Instance.SaveData();
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    public void SaveData()
    {
        saveLoadManager = new SaveLoadManager();
        GameData.CurrentScene = SceneManager.GetActiveScene().name;
        Debug.Log(GameData.CurrentScene);
        saveLoadManager.Save();
    }

    private void LoadData()
    {
        saveLoadManager = new SaveLoadManager();
        saveLoadManager.Load();
        ChangeScene(GameData.CurrentScene);
    }

    private void ChangePlayButton(string text)
    {
        var playButton = GameObject.Find("PlayButton");

        playButton.GetComponent<TextMeshProUGUI>().text = text;
        if (File.Exists(Application.persistentDataPath + "/StickmanData.json"))
        {
            playButton.GetComponent<Button>().onClick.AddListener(LoadData);    
        }
        else
        {
            playButton.GetComponent<Button>().onClick.RemoveListener(LoadData);
        }
    }
    
    private void ResetData()
    {
        saveLoadManager = new SaveLoadManager();
        saveLoadManager.DeleteSave();
        
        GameData.PlayerHealth = 30;
        GameData.BulletAmmo = 5;
        GameData.PlayerScore = 0;
        GameData.CurrentScene = "FirstLevel";
        GameData.IsWin = false;
        ChangePlayButton("Play");
    }

    private void LoadPosition()
    {
        var player = GameObject.Find("Player");
        Vector3 localPosition;
        localPosition.x = GameData.PlayerPosition[0];
        localPosition.y = GameData.PlayerPosition[1];
        localPosition.z = GameData.PlayerPosition[2];
        player.transform.position = localPosition;
    }

    public void ResetDataAndReload()
    {
        ResetData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void InitializePlayer()
    {
        //Sets player health slider and its values
        playerHealthSlider = GameObject.Find("Player").GetComponentInChildren<Slider>();
        playerHealthSlider.value = GameData.PlayerHealth;

        if (!File.Exists(Application.persistentDataPath + "/StickmanData.json"))
        {
            playerHealthSlider.maxValue = GameData.PlayerHealth;
        }
        else
        {
            Instance.LoadPosition();
        }
    }

    private void CheckHighScore()
    {
        var scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        scoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    private void AddHighScore()
    {
        //If never initialized before, high score will be set to the default value of 0
        //And if player score is higher than the high score, then it will update itself
        //High score will be saved and updated locally in the player's computer so that when the game restarts
        //the high score value is never lost
        if (GameData.PlayerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", GameData.PlayerScore);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            if (File.Exists(Application.persistentDataPath + "/StickmanData.json"))
            {
                ChangePlayButton("Continue");
            }

            if (GameData.PlayerHealth <= 0 || GameData.IsWin)
            {
                ResetData();
            }
        }
        else if (scene.name == "FirstLevel")
        {
            if (this != Instance) return;
            
            InitializePlayer();
        }
        else if (scene.name == "SecondLevel")
        {
            if (this != Instance) return;
            
            InitializePlayer();
        }
        else if (scene.name == "ScoreScene")
        {
            if (this != Instance) return;
            CheckHighScore();
        }
        else if (scene.name == "StatScene") 
        {
            var statText = GameObject.Find("StatText").GetComponent<TextMeshProUGUI>();
            var scoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();

            if (!GameData.IsWin)
            {
                statText.text = "You Lost!";
                scoreText.text = $"Score: {GameData.PlayerScore}";
                AddHighScore();
            } else if (GameData.IsWin)
            {
                statText.text = "You Win!";
                scoreText.text = $"Score: {GameData.PlayerScore}";
                AddHighScore();
            }
        }
    }
}
