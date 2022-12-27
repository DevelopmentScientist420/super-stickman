using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/EnemyScriptableObject", order = 1)]
public class EnemySO : ScriptableObject
{
    public GameObject enemyObject, enemyBullet;
    public int scoreValue, health, strength;
}
