using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float movementSpeed;                    // Speed of the character
    private bool isFriendly;                       // Determines if the character is friendly or an enemy
    private Rigidbody2D characterModel;            // Reference to the Rigidbody2D component
    private CharacterDetection characterDetection; // Reference to the CharacterDetection component
    private CharacterAttack characterAttack;       // Reference to the CharacterAttack for friendly status
    public bool isMoving = true;                   // Store the movement state for reference by other scripts
    public bool freeze = false;                    // Determines if the character should move

    void Start()
    {
        characterAttack = GetComponent<CharacterAttack>();
        isFriendly = characterAttack.isFriendly;
        characterModel = GetComponent<Rigidbody2D>();
        characterDetection = GetComponent<CharacterDetection>();
    }

    void Update()
    {
        if (!freeze)
        {
            MoveCharacter();
        } else
        {
            characterModel.velocity = Vector2.zero;
        }
    }

    // Method to move the character
    void MoveCharacter()
    {
        if (!characterModel) return;

        // Check for obstacles or targets in the way using CharacterDetection
        Collider2D detected = characterDetection.DetectTarget(characterDetection.stoppingRange, characterDetection.detectionLayer);

        if (detected == null || detected.gameObject.layer == characterDetection.detectionLayer)
        {
            // Move forward if no target detected or detected target is not on the opposite layer
            Vector2 direction = isFriendly ? Vector2.right : Vector2.left;
            characterModel.velocity = new Vector2(movementSpeed * direction.x, characterModel.velocity.y);
            isMoving = true;
        }
        else
        {
            // Stop if there's a detected target or obstacle on the opposite layer
            characterModel.velocity = Vector2.zero;
            Debug.Log(gameObject.name + " stopped due to detected target: " + detected.name);
            isMoving = false;
        }
    }
}
