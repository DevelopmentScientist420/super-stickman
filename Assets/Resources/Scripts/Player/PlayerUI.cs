using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : Player
{
    protected override void Start()
    {
        base.Start();
        UpdateAmmoText(GameData.BulletAmmo.ToString());
    }

    public static void UpdateAmmoText(string text)
    {
        ammoText.text = $"Ammo: {text}/5";
    }
}
