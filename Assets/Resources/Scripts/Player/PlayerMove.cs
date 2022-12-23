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
    }

    public void Move(Vector2 input)
    {
        var dirX = input.x;
        var dirY = rb.velocity.y;

        rb.velocity = new Vector2(dirX * speed, dirY);

        switch (dirX)
        {
            case < 0f:
                playerObject.transform.localRotation = Quaternion.Euler(new Vector3(0, -180, 0));
                GameData.BulletDirection = new Vector2(-5f, 0f);
                break;
            case > 0f:
                playerObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                GameData.BulletDirection = new Vector2(5f, 0f);
                break;
        }
        
        //If true, player moves with appropriate animation
        if (isMoving)
        {
            playerAnimator.SetBool("isRun", true);
            playerAnimator.SetBool("isIdle", false);
            switch (rb.velocity.y)
            {
                case > .1f:
                    playerAnimator.SetBool("isRun", false);
                    playerAnimator.SetBool("isJump", true);
                    break;
                case < -.1f:
                    playerAnimator.SetBool("isRun", true);
                    playerAnimator.SetBool("isJump", false);
                    break;
            }
        }
        else
        {
            playerAnimator.SetBool("isRun", false);
            playerAnimator.SetBool("isIdle", true);
            
            //Jumping function
            switch (rb.velocity.y)
            {
                case > .1f:
                    playerAnimator.SetBool("isJump", true);
                    playerAnimator.SetBool("isIdle", false);
                    break;
                case < -.1f:
                    playerAnimator.SetBool("isJump", false);
                    playerAnimator.SetBool("isIdle", true);
                    break;
            }
        }
    }
}
