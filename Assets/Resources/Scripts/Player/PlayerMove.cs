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
    private InputManager inputManager;
    
    protected override void Start()
    {
        base.Start();
        speed = playerSpeed;
        inputManager = GetComponent<InputManager>();
    }

    public void Move(Vector2 input)
    {
        var dirX = input.x;
        var dirY = rb.velocity.y;

        rb.velocity = new Vector2(dirX * speed, dirY);
        
        //Flips player left and right
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
            switch (dirY)
            {
                case > .1f:
                    playerAnimator.SetBool("isRun", false);
                    playerAnimator.SetBool("isJump", true);
                    inputManager.playerControl.Jump.Disable();
                    break;
                case < -.1f:
                    playerAnimator.SetBool("isRun", true);
                    playerAnimator.SetBool("isJump", false);
                    inputManager.playerControl.Jump.Enable();
                    break;
            }
        }
        else
        {
            playerAnimator.SetBool("isRun", false);
            playerAnimator.SetBool("isIdle", true);
            
            //Jumping function
            switch (dirY)
            {
                case > .1f:
                    playerAnimator.SetBool("isJump", true);
                    playerAnimator.SetBool("isIdle", false);
                    inputManager.playerControl.Jump.Disable();
                    break;
                case < -.1f:
                    playerAnimator.SetBool("isJump", false);
                    playerAnimator.SetBool("isIdle", true);
                    inputManager.playerControl.Jump.Enable();
                    break;
            }
        }
    }
}
