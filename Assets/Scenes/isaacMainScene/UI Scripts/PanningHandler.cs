using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanningHandler : MonoBehaviour
{
    public float scrollSpeed = 10f; // Speed at which the camera moves
    private float scrollDirection = 0; // Current scroll direction (negative for left, positive for right)

    // Define the boundaries for the camera's x position
    public float minX = -8f;
    public float maxX = 8.15f;

    void Update()
    {
        if (scrollDirection != 0)
        {
            // Move the camera based on the current scroll direction
            Vector3 position = transform.position;
            position.x += scrollDirection * Time.deltaTime;

            // Clamp the x position to keep the camera within the defined bounds
            position.x = Mathf.Clamp(position.x, minX, maxX);

            // Update the camera's position
            transform.position = position;
        }
    }

    public void SetScrollDirection(float direction)
    {
        scrollDirection = direction;
    }
}
