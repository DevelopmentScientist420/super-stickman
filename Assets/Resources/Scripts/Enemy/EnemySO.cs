using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "ScriptableObjects/EnemyScriptableObject", order = 1)]
public class EnemySO : ScriptableObject
{
    public GameObject enemyObject;
    public int score, health;
}
