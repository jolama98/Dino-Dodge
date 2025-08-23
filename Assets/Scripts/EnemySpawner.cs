using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour

{
    // how far away from the player will our enemy spawn
    public float spawnDistance = 10f;
    // how frequently will our enemies spawn
    public float spawnInterval = 2f;
    // slot for our pre-fab to go
    public GameObject enemy;
    private Transform playerLocation;
    private float timer = 0f;

    void Start()
    {
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (playerLocation == null) return;

        timer += Time.deltaTime; // advance timer
        if (timer >= spawnInterval)
        {
            Debug.Log("Invite more friends🦖");
            timer = 0f; // reset timer
            Spawn();
        }
    }

      void Spawn()
    {
        //position of the current game object (the spawner) as the center point.
        Vector2 center = gameObject.transform.position;

        // Generate a random direction vector within a unit circle (normalized to have a magnitude of 1).
        Vector2 dir = Random.insideUnitCircle.normalized;

        // Calculate the spawn position by moving from the center in the random direction,
        Vector2 spawnPosition = center + dir * spawnDistance;

        // Instantiate (create) a new enemy object at the calculated spawn position.
        // The enemy will have no rotation (Quaternion.identity means no rotation).
        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }

}
