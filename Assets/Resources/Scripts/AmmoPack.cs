using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoPack : MonoBehaviour
{
    private TextMeshProUGUI ammoText;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            AddAmmo();
        }
        else
        {
            Debug.Log("Collided object is not Player!");
        }
    }

    private void AddAmmo()
    {
        if (GameData.BulletAmmo != 5)
        {
            var ammoAdd = 5 - GameData.BulletAmmo;
            GameData.BulletAmmo += ammoAdd;
            PlayerUI.UpdateAmmoText(GameData.BulletAmmo.ToString());
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Ammo full!");
        }
    }
}
