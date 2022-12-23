using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    protected float speed;

    protected virtual void OnEnable()
    {
        var direction = GameData.BulletDirection;
        direction.Normalize();
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }
}
