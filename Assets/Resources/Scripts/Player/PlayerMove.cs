using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMove : Player
{
    [SerializeField] private float playerSpeed;
    protected override void Start()
    {
        base.Start();
        speed = playerSpeed;
    }

    public void Move(Vector2 input)
    {
        var dirX = input.x;
        var dirY = rb.velocity.y;

        rb.velocity = new Vector2(dirX * speed, dirY);
    }
}
