using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : Player
{
    protected override void Start()
    {
        base.Start();
        UpdateText($"Ammo: {GameData.BulletAmmo}/5");
    }

    public static void UpdateText(string text)
    {
        ammoText.text = text;
    }
    
    public static IEnumerator DelayedText(float delay, string text)
    {
        UpdateText(text);
        yield return new WaitForSeconds(delay);
        UpdateText($"Ammo: {GameData.BulletAmmo}/5");
    }
}
