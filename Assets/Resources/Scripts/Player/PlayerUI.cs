using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : Player
{
    protected override void Start()
    {
        base.Start();
        UpdateAmmoText($"Ammo: {GameData.BulletAmmo}/5");
        UpdateScoreText($"Score: {GameData.PlayerScore}");
    }

    public static void UpdateAmmoText(string text)
    {
        ammoText.text = text;
    }

    public static void UpdateScoreText(string text)
    {
        scoreText.text = text;
    }
    
    public static IEnumerator DelayedText(float delay, string text)
    {
        UpdateAmmoText(text);
        yield return new WaitForSeconds(delay);
        UpdateAmmoText($"Ammo: {GameData.BulletAmmo}/5");
    }
}
