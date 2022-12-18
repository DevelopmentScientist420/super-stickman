using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : Bullet
{
    protected override void OnEnable()
    {
        base.OnEnable();
        speed = 10f;
    }
}
