using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public void Fire(GameObject bullet)
    {
        if (bullet != null)
        {
            bullet.transform.position = this.transform.position;
            bullet.SetActive(true);
        }
    }
}
