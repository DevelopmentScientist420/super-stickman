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

    private void EnemyDamage()
    {
        if (health != 0)
        {
            health--;
            GameData.PlayerScore += scoreValue;
        }
        else if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void EnemyDie()
    {
        GameData.PlayerScore += scoreValue;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            EnemyDamage();
            col.gameObject.SetActive(false);
            Debug.Log($"{GameData.PlayerScore} and enemy health is {health}");
        }
        else if (col.gameObject.CompareTag("Player"))
        {
            GameData.PlayerHealth -= strength;
            Destroy(this.gameObject);
            Debug.Log($"Player health is {GameData.PlayerHealth}");
        }
    }
}
