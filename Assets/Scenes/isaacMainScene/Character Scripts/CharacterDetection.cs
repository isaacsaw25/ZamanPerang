using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDetection : MonoBehaviour
{
    public float stoppingRange = 0f;        // Stop before all other units
    public float detectionRange = 3f;       // Detection range for nearby targets
    public LayerMask detectionLayer;        // Layer mask to filter targets
    private bool isFriendly;                 // Determines if the character is friendly or an enemy
    private CharacterAttack characterAttack; // Reference the character attack for friendly status

    private void Start()
    {
        characterAttack = GetComponent<CharacterAttack>();
        isFriendly = characterAttack.isFriendly;
    }

    // Detects targets in front of the character within the specified range
    public Collider2D DetectTarget(float range, LayerMask layers)
    {
        Vector2 origin = transform.position;
        Vector2 direction = isFriendly ? Vector2.right : Vector2.left;

        // Adjust the origin to be just outside the character's own collider based on its size
        Collider2D characterCollider = GetComponent<Collider2D>();
        if (characterCollider is BoxCollider2D boxCollider)
        {
            float offset = boxCollider.size.x / 2 + 0.1f; // Adding a small buffer to avoid self-hit
            origin += direction * offset;
        }
        else if (characterCollider is CircleCollider2D circleCollider)
        {
            float offset = circleCollider.radius + 0.1f; // Adding a small buffer to avoid self-hit
            origin += direction * offset;
        }

        // Cast the ray and ignore the character's own collider
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, range, layers);
        Debug.DrawRay(origin, direction * range, Color.red); // Visualize the detection ray

        if (hit.collider != null && hit.collider != characterCollider)
        {
            Debug.Log("Detected target: " + hit.collider.name);
            return hit.collider;
        }

        return null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + (isFriendly ? Vector3.right : Vector3.left) * detectionRange);
    }
}
