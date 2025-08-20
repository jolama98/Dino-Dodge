using System;
using UnityEngine;

public class PlayerController : Character
{
    // public float moveSpeed = 5f;

    private Vector2 movement; 
    private Rigidbody2D rb;

    new void Start()
    {
        base.Start(); // call the base class start
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }
}