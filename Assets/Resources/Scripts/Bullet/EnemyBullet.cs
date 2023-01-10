using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    private GameObject player;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;
    
    protected override void OnEnable()
    {
        base.OnEnable();
        speed = bulletSpeed;
        player = GameObject.Find("Player");
        direction = player.transform.position - transform.position;
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, 0f).normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.DamagePlayer(bulletDamage);
            GameManager.Instance.SaveData();
            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
