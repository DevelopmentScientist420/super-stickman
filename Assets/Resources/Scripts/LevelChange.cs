using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //Resets position data, so in the next level the player spawns in the starting point
            Array.Clear(GameData.PlayerPosition, 0, GameData.PlayerPosition.Length);
            if (SceneManager.GetActiveScene().name == "FirstLevel")
            {
                GameManager.Instance.ChangeScene("SecondLevel");
            }
            else
            {
                GameManager.Instance.ChangeScene("StatScene");
            }
        }
    }
}
