using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    [HideInInspector] public int startHealth, strength, scoreValue;
    private TextMeshProUGUI healthText;
    private int health;
    
    private void Start()
    {
        healthText = GetComponentInChildren<TextMeshProUGUI>();
        health = startHealth;
        healthText.text = health.ToString();
    }

    private void Update()
    {
        if (health <= 0)
        {
            EnemyDie();
        }
    }

    private void EnemyDamage()
    {
        if (health != 0)
        {
            health--;
            healthText.text = health.ToString();
        }
    }

    public void EnemyDie()
    {
        GameData.PlayerScore = GameData.PlayerScore += scoreValue;
        PlayerUI.UpdateScoreText($"Score: {GameData.PlayerScore}");
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            EnemyDamage();
            col.gameObject.SetActive(false);
        }
        else if (col.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.DamagePlayer(strength);
            Destroy(this.gameObject);
        }
    }
}
