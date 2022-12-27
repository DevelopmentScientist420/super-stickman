using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    
    public int startHealth, strength, scoreValue;
    private int health;
    
    private void Start()
    {
        health = startHealth;
        
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
        }
    }

    public void EnemyDie()
    {
        GameData.PlayerScore += scoreValue;
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
