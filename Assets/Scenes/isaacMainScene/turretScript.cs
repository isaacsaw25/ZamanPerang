using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab for the projectile
    public Transform firePoint;         // The point from where projectiles are fired
    public LayerMask enemyLayer;        // Layer mask to filter for enemy targets
    public float fireRate = 1f;         // Time between each shot
    public float detectionRadius = 3f;  // Detection radius for the turret to find the nearest enemy
    public bool isFriendly;             // Determines if the turret is friendly or an enemy

    private float nextFireTime;

    private void Start()
    {
        if (firePoint == null)
        {
            firePoint = gameObject.transform; // Ensure the fire point is set to the turret's transform if not assigned
        }
    }

    void Update()
    {
        // Check if it's time to fire again
        if (Time.time >= nextFireTime)
        {
            // Check for enemies within detection radius
            Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, detectionRadius, enemyLayer);

            // If there's at least one enemy in range, fire a projectile
            if (enemiesInRange.Length > 0)
            {
                ShootProjectile(enemiesInRange[0]); // Target the first enemy detected
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void ShootProjectile(Collider2D target)
    {
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Projectile projectileScript = projectile.GetComponent<Projectile>();

            if (projectileScript != null)
            {
                // Calculate the direction from the fire point to the target
                Vector3 direction = (target.transform.position - firePoint.position).normalized;
                projectileScript.SetDirection(direction);

                // Set the ownership of the projectile based on the turret's friendliness
                projectileScript.SetOwnership(isFriendly);

                Debug.Log((isFriendly ? "Friendly" : "Enemy") + " turret fired a projectile towards " + direction);
            }
            else
            {
                Debug.LogWarning("Projectile script is missing on the instantiated projectile.");
            }
        }
        else
        {
            Debug.LogWarning("Projectile prefab or fire point is not assigned for turret " + gameObject.name);
        }
    }

    // Optional: Visualize the detection radius in the Scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
