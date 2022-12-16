using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMove : Player
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private float playerSpeed;
    public bool isMoving;
    
    protected override void Start()
    {
        base.Start();
        speed = playerSpeed;
        playerAnimator.SetTrigger("isIdle");
    }

    public void Move(Vector2 input)
    {
        var dirX = input.x;
        var dirY = rb.velocity.y;

        rb.velocity = new Vector2(dirX * speed, dirY);
        
        if (isMoving)
        {
            playerObject.transform.localRotation = dirX switch
            {
                < 0f => Quaternion.Euler(new Vector3(0, -180, 0)),
                > 0f => Quaternion.Euler(new Vector3(0, 0, 0)),
                _ => playerObject.transform.localRotation
            };
            playerAnimator.ResetTrigger("isIdle");
            playerAnimator.SetTrigger("isRun");
        }
        else
        {
            playerAnimator.ResetTrigger("isRun");
            playerAnimator.SetTrigger("isIdle");
        }
        
    }
}
