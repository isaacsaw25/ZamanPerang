using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLogicScript : MonoBehaviour
{
    public bool isFriendly;             // Determines if the character is friendly or an enemy
    public float movementSpeed;         // Speed of the character
    public float range;                 // Range of the ray for detection
    public LayerMask layerToDetect;     // Layers to detect, excluding the character's own layer

    public float maxHealth = 100;       // Set max health of the character
    public float currentHealth;         // Variable to keep track of the health
    public GameObject healthBarPrefab; // Prefab for the health bar UI
    public Vector3 healthBarOffset = new(0, 1.2f, 0); // Offset for the health bar position

    private GameObject healthBarInstance; // Instance of the health bar
    private Image healthFill; // Reference to the fill percentage component in the health bar

    public Rigidbody2D characterModel;    // Reference to the Rigidbody2D component
    private Collider2D characterCollider; // Reference to the character's own collider
    private SpriteRenderer sprite;        // Reference to the character's own sprite

    void Start()
    {
        characterCollider = GetComponent<Collider2D>(); // Get the character's collider
        sprite = GetComponent<SpriteRenderer>();        // Get the character's sprite reference
        currentHealth = maxHealth;                      // Set the current health to max health on spawn
        if (!isFriendly)                                
        {
            sprite.flipX = true;                        // Render the enemy sprites as flipped
            gameObject.layer = 6;                       // Set the layer to enemy
        }

        // Instantiate the health bar and set it as a child of the character
        if (healthBarPrefab != null)
        {
            healthBarInstance = Instantiate(healthBarPrefab, transform.position + healthBarOffset, Quaternion.identity, transform);

            // Find the Image component responsible for the fill
            healthFill = healthBarInstance.transform.Find("CurrentHealth").GetComponent<Image>();
            if (healthFill != null)
            {
                healthFill.fillAmount = currentHealth / maxHealth; // Set initial fill amount
            }
            healthBarInstance.SetActive(false); // Initially hide the health bar
        }
    }

    void Update()
    {
        DetectEnemy();

        if (healthBarInstance != null)
        {
            healthBarInstance.transform.position = transform.position + healthBarOffset;
        }
        // Check health status
        if (currentHealth <= 0) { 
            Destroy(gameObject);
            Debug.Log(gameObject.name + " died.");
        }
    }

    void DetectEnemy()
    {
        // Adjust the origin based on the size of the collider to avoid self-detection
        Vector2 origin = transform.position;

        // Determine the correct direction for the ray based on whether the character is friendly
        Vector2 direction = isFriendly ? Vector2.right : Vector2.left;

        // Adjust the origin to be just outside the character's own collider based on its size
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
        // Add more cases if you are using other types of colliders

        // Cast the ray and ignore the character's own collider
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, range, layerToDetect);

        if (hit.collider != null && hit.collider != characterCollider)
        {
            // Stop the character if the ray hits something other than itself
            Move(false);
        }
        else
        {
            // Move the character if the ray doesn't hit anything or hits itself
            Move(true);
        }

        // Visualize the ray in the Scene view
        Debug.DrawRay(origin, direction * range, Color.red);
    }

    void Move(bool isMoving)
    {
        if (isMoving)
        {
            // Set the velocity to move the character
            characterModel.velocity = new Vector2(movementSpeed * 
                                   (isFriendly ? 1 : -1), characterModel.velocity.y);
        }
        else
        {
            // Stop the character by setting velocity to zero
            characterModel.velocity = Vector2.zero;
        }
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        // Update the health bar display
        if (healthFill != null)
        {
            healthFill.fillAmount = (float)currentHealth / (float)maxHealth; // Update the fill 
        }

        // TO-DO: Implement damage indicators/particles on hit
    }
    void OnMouseEnter()
    {
        // Show the health bar on mouse hover
        if (healthBarInstance != null)
        {
            healthBarInstance.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        // Hide the health bar when the mouse leaves
        if (healthBarInstance != null)
        {
            healthBarInstance.SetActive(false);
        }
    }
}
