using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : Player
{
    private static readonly int IsShoot = Animator.StringToHash("isShoot");
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
            playerAnimator.SetTrigger(IsShoot);
            if (fireInstance == null) return;
            var bullet = objectPool.GetPooledObject();
            fireInstance.Fire(bullet);
            GameData.BulletAmmo--;
            PlayerUI.UpdateAmmoText($"Ammo: {GameData.BulletAmmo}/5");
        }
        else
        {
            StartCoroutine(PlayerUI.DelayedText(2f, "No ammo!"));
        }
    }
}
