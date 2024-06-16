using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public float atkRate = 1.0f;
    public float fireRate = 1.0f; // (Time between attacks)
    public float meleeDamage = 10f;
    public float rangedDamage = 8f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public bool isFriendly;
    public bool isRanged;

    private float lastMeleeAttackTime = 0;
    private float lastRangedAttackTime = 0;
    private bool isMeleeing = false;
    private CharacterDetection characterDetection;
    private SpriteRenderer CharacterRenderer;
    private CharacterMovement characterMovement;

    void Start()
    {
        // Pull all the info from other scripts
        CharacterRenderer = GetComponent<SpriteRenderer>();
        CharacterRenderer.flipX = !isFriendly; // Flip enemy sprites
        gameObject.layer = LayerMask.NameToLayer(isFriendly ? "Friendly" : "Enemy"); // Send enemy units to enemy layer
        characterDetection = GetComponent<CharacterDetection>();
        characterMovement = GetComponent<CharacterMovement>();
    }

    void Update()
    {
        Collider2D meleeTarget = characterDetection.DetectTarget(characterDetection.stoppingRange,
                                                   LayerMask.GetMask(isFriendly ? "Enemy" : "Friendly"));
        if (meleeTarget != null)
        {
            isMeleeing = true;
            if (Time.time >= lastMeleeAttackTime + atkRate) { 
                PerformMeleeAttack(meleeTarget);
                lastMeleeAttackTime = Time.time;
            }
        }
        if (isRanged && !isMeleeing && Time.time >= lastRangedAttackTime + fireRate)
        {
            firePoint = gameObject.transform;
            PerformRangedAttack();
            isMeleeing = false;
        }
    }

    public void PerformMeleeAttack(Collider2D target)
    {
        CharacterHealth enemyHealth = target.GetComponent<CharacterHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(meleeDamage);
            Debug.Log(gameObject.name + " melee attack dealt " + meleeDamage + " damage to " + target.name);
        }
    }

    void PerformRangedAttack()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            Collider2D target = characterDetection.DetectTarget(characterDetection.detectionRange, characterDetection.detectionLayer);
            if (target != null)
            {
                GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
                Projectile projectileScript = projectile.GetComponent<Projectile>();

                if (projectileScript != null)
                {
                    Vector2 direction = (target.transform.position - firePoint.position).normalized;
                    projectileScript.SetDirection(direction);
                    projectileScript.SetOwnership(isFriendly);
                    projectileScript.damage = rangedDamage;

                    Debug.Log(gameObject.name + " fired a " + (isFriendly ? "friendly" : "enemy") + " projectile towards " + direction);
                }

                lastRangedAttackTime = Time.time;
            }
        }
    }
}
