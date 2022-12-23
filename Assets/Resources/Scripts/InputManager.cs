using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInputAction playerInputAction;
    public PlayerInputAction.PlayerControlsActions playerControl;

    private PlayerMove playerMove;
    private PlayerJump playerJump;
    private PlayerShoot playerShoot;

    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
        playerControl = playerInputAction.PlayerControls;

        playerMove = GetComponent<PlayerMove>();
        playerJump = GetComponent<PlayerJump>();
        playerShoot = GetComponent<PlayerShoot>();

        playerControl.Movement.performed += ctx => playerMove.isMoving = true;
        playerControl.Movement.canceled += ctx => playerMove.isMoving = false;
        
        playerControl.Jump.performed += ctx => playerJump.Jump();
        playerControl.Shoot.performed += ctx => playerShoot.Shoot();
    }

    private void Update()
    {
        playerMove.Move(playerControl.Movement.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        playerControl.Enable();
    }

    private void OnDisable()
    {
        playerControl.Disable();
    }
}
