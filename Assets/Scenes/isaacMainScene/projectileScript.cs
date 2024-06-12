using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Projectile : MonoBehaviour
{
    public float speed;                 // Speed of the projectile
    public GameObject target;           // Reference to the target GameObject
    public float damage;                // Damage dealt by the projectile
    public LayerMask enemyLayer;        // Layer mask to filter for enemy targets

    void Start()
    {
        // Set the collider to be a trigger to avoid physical collisions
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        collider.isTrigger = true;
        SetTarget();
    }

    void Update()
    {
        if (target != null)
        {
            // Calculate direction towards the target
            Vector3 direction = (target.transform.position - transform.position).normalized;

            // Move the projectile towards the target
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);
        CharacterLogicScript character = other.GetComponent<CharacterLogicScript>();
        if (((1 << other.gameObject.layer) & enemyLayer) != 0)
        {
            character.TakeDamage(damage);

            // Destroy the projectile after hitting the target
            Destroy(gameObject);
        }
    }
    void SetTarget()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, 50, enemyLayer);
        float nearestDistance = Mathf.Infinity;

        foreach (Collider2D enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < nearestDistance)
            {
                nearestDistance = distanceToEnemy;
                target = enemy.gameObject;
            }
        }
        
    }
}
