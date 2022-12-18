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
    }
}
