using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   // Set up properties the controller needs
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement; // has x,y properties

    void Start()
    {
        // Get the Rigidbody2D component attached to the player GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    // Called once per frame to handle input
    void Update()
    {
        // Get horizontal and vertical input (WASD or arrow keys)
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    // Called at fixed intervals to handle physics-based movement
    void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }
}
