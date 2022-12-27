using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoPack : Interactable
{
    protected override void Interact()
    {
        AddAmmo();
    }

    private void AddAmmo()
    {
        if (GameData.BulletAmmo != 5)
        {
            var ammoAdd = 5 - GameData.BulletAmmo;
            GameData.BulletAmmo += ammoAdd;
            PlayerUI.UpdateAmmoText($"Ammo: {GameData.BulletAmmo}/5");
            this.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(PlayerUI.DelayedText(2f, "Ammo full!"));
        }
    }
}
