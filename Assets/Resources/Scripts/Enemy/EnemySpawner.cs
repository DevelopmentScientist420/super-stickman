using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemySO> enemySoList;

    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        var enemyChoice = Random.Range(0, enemySoList.Count);
        var enemyInstance = Instantiate(enemySoList[enemyChoice].enemyObject, transform.position, Quaternion.identity);
        enemyInstance.GetComponent<Enemy>().startHealth = enemySoList[enemyChoice].health;
        enemyInstance.GetComponent<Enemy>().strength = enemySoList[enemyChoice].strength;
        enemyInstance.GetComponent<Enemy>().scoreValue = enemySoList[enemyChoice].scoreValue;
        enemyInstance.GetComponent<EnemyFire>().enemyBullet = enemySoList[enemyChoice].enemyBullet;
    }
}
