using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Bullet : MonoBehaviour
{
    protected float speed;
    protected Vector2 direction;

    protected virtual void OnEnable()
    {
        direction = GameData.BulletDirection;
        direction.Normalize();
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }
}
