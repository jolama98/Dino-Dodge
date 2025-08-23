using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public Vector3 movementDir;
    public bool onCooldown;
    public Transform playerLocation;

    new void Start()
    {
        base.Start(); // call the base class start

        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
        movementDir = (playerLocation.position - transform.position).normalized;
    }

    void Update()
    {
        if (onCooldown) return;

        transform.position += movementDir * Time.deltaTime * moveSpeed;
        // move towards the 🎯
        transform.position += movementDir * Time.deltaTime * moveSpeed;
    }
    
        void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
          onCooldown = true; 
          // Schedule the "ReActivate" method to be called after 1 second
          Invoke("ReActivate", 1f); 
        }
    }

    void ReActivate()
    {
      onCooldown = false;
      playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
      movementDir = (playerLocation.position - transform.position).normalized;
    }

}
