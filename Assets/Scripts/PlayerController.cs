using System;
using UnityEngine;

public class PlayerController : Character
{
    // public float moveSpeed = 5f;

    // private Vector2 movement;
     private Vector2 _movementInput = new();
    private Rigidbody2D _rb;


    private Animator _anim;

    new void Start()
    {
        _anim = GetComponent<Animator>();
        base.Start(); // call the base class start
        _rb = GetComponent<Rigidbody2D>();
        _anim.SetBool("isRunning", false);
    }

    void Update()

    {
         _movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _movementInput.Normalize();


        if (_movementInput.x > .1f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (_movementInput.x < -.1f)
        {
            transform.localScale = new Vector2(1, 1);
        }

        if (Math.Abs(_movementInput.magnitude) > .1f)
        {
            _anim.SetBool("isRunning", true);
        }
        else
        {
            _anim.SetBool("isRunning", false);
        }


        // movement.x = Input.GetAxis("Horizontal");
        // movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        // rb.velocity = movement * moveSpeed;
        _rb.MovePosition(_rb.position + _movementInput * moveSpeed * Time.fixedDeltaTime);
    }
    
     public void OnDeath()
    {
        _anim.enabled = false;
        enabled = false;
    }
}