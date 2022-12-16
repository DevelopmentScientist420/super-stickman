using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerJump : Player
{
    [SerializeField] private float jumpSpeed;
    
    protected override void Start()
    {
        base.Start();
        jump = jumpSpeed;
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        // if(playerAnimator.GetTr)
    }
}
