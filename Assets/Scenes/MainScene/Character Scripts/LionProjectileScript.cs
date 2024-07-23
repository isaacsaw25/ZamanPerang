using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionProjectileScript : MonoBehaviour
{
    public float speed = 10f;                // Speed of the projectile
    public float damage;               // Damage dealt by the projectile
    public float timeToLive = 3.0f;          // Self-destruct timer 
    public Vector3 targetDirection;          // Direction to persist towards
    public bool isFriendlyProjectile;        // Indicates if the bullet is from a friendly unit

    void Start()
    {
        Destroy(gameObject, timeToLive); // Ensure the projectile self-destructs after a set time

        // Set the collider to be a trigger to avoid physical collisions
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }

        // Set the initial direction
        if (targetDirection == Vector3.zero)
        {
            targetDirection = isFriendlyProjectile ? Vector3.right : Vector3.left; // Default direction
        }
    }

    void Update()
    {
        // Move the projectile in the target direction
        transform.position += speed * Time.deltaTime * targetDirection.normalized;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision is with a valid target based on ownership
        if (isFriendlyProjectile)
        {
            if (((1 << other.gameObject.layer) & LayerMask.GetMask("Enemy")) != 0)
            {
                HandleCollision(other);
            }
        }
        else
        {
            if (((1 << other.gameObject.layer) & LayerMask.GetMask("Friendly")) != 0)
            {
                HandleCollision(other);
            }
        }
    }

    void HandleCollision(Collider2D other)
    {
        Debug.Log("Projectile hit: " + other.name);

        CharacterHealth character = other.GetComponent<CharacterHealth>();
        if (character != null && other.GetComponent<BaseScript>() == null)
        {
            character.TakeDamage(damage);
        }

        if (other.GetComponent<BaseScript>() != null)
        {
            Destroy(gameObject);
        } 
    }

    public void SetDirection(Vector3 direction)
    {
        targetDirection = direction.normalized;
    }

    public void SetOwnership(bool isFriendly)
    {
        isFriendlyProjectile = isFriendly;
    }
}
