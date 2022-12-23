using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    protected Animator playerAnimator;
    protected float speed;
    protected float jump;
    protected Rigidbody2D rb;
    protected static TextMeshProUGUI ammoText;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        ammoText = GameObject.Find("AmmoText").GetComponent<TextMeshProUGUI>();
        speed = 0;
        GameData.PlayerHealth = 30;
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
