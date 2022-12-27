using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }

    public void DamagePlayer(int damageValue)
    {
        GameData.PlayerHealth -= damageValue;
        // Debug.Log($"Player health is {GameData.PlayerHealth}");
    }
}
