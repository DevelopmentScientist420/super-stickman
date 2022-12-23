using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Player : MonoBehaviour
{
    protected Animator playerAnimator;
    protected float speed;
    protected float jump;
    protected Rigidbody2D rb;
    protected static TextMeshProUGUI ammoText;

    private int playerHealth = 20;

    protected virtual void Start()
    {
        GameData.PlayerHealth = playerHealth;
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        ammoText = GameObject.Find("AmmoText").GetComponent<TextMeshProUGUI>();
        speed = 0;
    }

    private void Update()
    {
        playerHealth = GameData.PlayerHealth;
        // if (playerHealth <= 0)
        // {
        //     Debug.Log("IT WORKS!");
        // }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.activeSelf)
        {
            if (col.gameObject.GetComponent<Interactable>() != null)
            {
                var interactable = col.gameObject.GetComponent<Interactable>();
                interactable.BaseInteract();
            }
        }
    }
}
