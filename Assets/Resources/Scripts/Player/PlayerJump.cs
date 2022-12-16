using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Player))]
public class PlayerJump : Player
{
    [SerializeField] private float jumpForce;

    protected override void Start()
    {
        base.Start();
        jump = jumpForce;
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jump);
    }
}
