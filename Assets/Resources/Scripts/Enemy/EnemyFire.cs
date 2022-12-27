using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] private float castDistance;
    [SerializeField] private float bulletDelay;
    [HideInInspector] public GameObject enemyBullet;
    [SerializeField] private GameObject gunTip;
    private float timer;

    private void FixedUpdate()
    {
        var ray = Physics2D.Linecast(transform.position, transform.position + Vector3.right * -castDistance, 
            1 << LayerMask.NameToLayer("Action"));
        if (ray.collider != null)
        {
            Debug.DrawLine(transform.position, ray.point, Color.blue);
            if (ray.collider.gameObject.CompareTag("Player"))
            {
                EnemyShoot();
            }
        }
    }

    private void EnemyShoot()
    {
        timer += Time.deltaTime;
        if (timer > bulletDelay)
        {
            Instantiate(enemyBullet, gunTip.transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
