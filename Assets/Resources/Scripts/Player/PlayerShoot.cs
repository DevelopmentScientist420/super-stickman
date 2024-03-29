using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : Player
{
    public ObjectPooling objectPool;
    private GunFire fireInstance;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        fireInstance = GetComponentInChildren(typeof(GunFire)) as GunFire;
    }

    public void Shoot()
    {
        if (GameData.BulletAmmo != 0)
        {
            playerAnimator.SetTrigger("isShoot");
            if (fireInstance == null) return;
            var bullet = objectPool.GetPooledObject();
            fireInstance.Fire(bullet);
            GameData.BulletAmmo--;
            PlayerUI.UpdateAmmoText($"Ammo: {GameData.BulletAmmo}/5");
        }
        else
        {
            StartCoroutine(PlayerUI.DelayedAmmoText(2f, "No ammo!"));
        }
    }
}
