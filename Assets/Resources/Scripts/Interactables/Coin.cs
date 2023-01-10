using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Interactable
{
    private int scoreValue = 5;
    
    protected override void Interact()
    {
        AddExtraPoints();
    }

    private void AddExtraPoints()
    {
        GameData.PlayerScore += scoreValue;
        PlayerUI.UpdateScoreText($"Score: {GameData.PlayerScore}");
        GameManager.Instance.SaveData();
        this.gameObject.SetActive(false);
    }
}
