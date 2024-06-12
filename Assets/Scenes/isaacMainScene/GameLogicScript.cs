using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicScript : MonoBehaviour
{
    public GameObject nearestEnemy;
    public float detectionRadius = 50f; // The area to search for enemies
    public LayerMask enemyLayer; // Layer mask to filter for enemy targets

    void Update()
    {
        // Find all colliders within the detection radius on the enemy layer
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, detectionRadius, enemyLayer);

        if (enemies.Length > 0)
        {
            GameObject leftmostEnemy = FindLeftmostEnemy(enemies);
            if (leftmostEnemy != null)
            {
                // Set the leftmost enemy as the target
                nearestEnemy = leftmostEnemy;
            }
        }
    }

    GameObject FindLeftmostEnemy(Collider2D[] enemies)
    {
        GameObject leftmostEnemy = null;
        float leftmostX = Mathf.Infinity;

        // Iterate through all detected enemies to find the one with the smallest x-coordinate
        foreach (Collider2D enemy in enemies)
        {
            if (enemy.transform.position.x < leftmostX)
            {
                leftmostX = enemy.transform.position.x;
                leftmostEnemy = enemy.gameObject;
            }
        }

        return leftmostEnemy;
    }
}

