using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class StompCollision : MonoBehaviour
{
    private Enemy enemy;

    private void Start()
    {
        enemy = transform.parent.GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            enemy.EnemyDie();
        }
    }
}
