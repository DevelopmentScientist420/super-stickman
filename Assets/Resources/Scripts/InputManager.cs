using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInputAction playerInputAction;
    private PlayerInputAction.PlayerControlsActions playerControl;

    private PlayerMove playerMove;
    private PlayerJump playerJump;

    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
        playerControl = playerInputAction.PlayerControls;

        playerMove = GetComponent<PlayerMove>();
        playerJump = GetComponent<PlayerJump>();

        playerControl.Movement.performed += ctx => playerMove.isMoving = true;
        playerControl.Movement.canceled += ctx => playerMove.isMoving = false;
        
        playerControl.Jump.performed += ctx => playerJump.Jump();
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
