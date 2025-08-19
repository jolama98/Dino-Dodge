using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Public properties let us assign these values, through Unity's UI
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    // Camera limits (world space)
    public Vector2 minBounds;
    public Vector2 maxBounds;

    // LateUpdate is called after all Update methods have been processed
    void LateUpdate()
    {

        
        // If the player reference is null, exit the method
        if (player == null) return;

        // Calculate the desired position of the camera based on the player's position and the offset
        Vector3 desiredPosition = player.position + offset;

        // Clamp X and Y so camera doesn’t go outside the limits
        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        // Smoothly interpolate the camera's position from its current position to the clamped position
        transform.position = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);
    }
}
