using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab for the projectile
    public Transform firePoint; // The point from where projectiles are fired
    public LayerMask enemyLayer; // Layer mask to filter for enemy targets
    public float fireRate = 1f; // Time between each shot
    public float detectionRadius = 10f; // Detection radius for the projectile to find the nearest enemy

    private float nextFireTime;

    private void Start()
    {
        firePoint = gameObject.transform;
    }
    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            ShootProjectile();
            nextFireTime = Time.time + fireRate;
        }
    }

    void ShootProjectile()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Projectile projectileScript = projectile.GetComponent<Projectile>();

            if (projectileScript != null)
            {
                // Pass the enemyLayer and detectionRadius to the projectile
                projectileScript.enemyLayer = enemyLayer;
                //projectileScript.detectionRadius = detectionRadius;
            }
        }
    }
}
