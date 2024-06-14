using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float movementSpeed;
    private bool isFriendly;
    private Rigidbody2D characterModel;
    private CharacterDetection characterDetection;
    private CharacterAttack characterAttack; // Reference the character attack for friendly status
    public bool isMoving; // Keep track of movement state

    void Start()
    {
        characterAttack = GetComponent<CharacterAttack>();
        isFriendly = characterAttack.isFriendly;
        characterModel = GetComponent<Rigidbody2D>();
        characterDetection = GetComponent<CharacterDetection>();
    }

    void Update()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        if (!characterModel) return;

        // Check for obstacles or targets in the way using CharacterDetection
        Collider2D detected = characterDetection.DetectTarget(characterDetection.stoppingRange, characterDetection.detectionLayer);

        if (detected == null)
        {
            // Move forward if no target detected
            Vector2 direction = isFriendly ? Vector2.right : Vector2.left;
            characterModel.velocity = new Vector2(movementSpeed * direction.x, characterModel.velocity.y);
            isMoving = true;
        }
        else
        {
            // Stop if there's a detected target or obstacle
            characterModel.velocity = Vector2.zero;
            isMoving = false;
        }
    }

    public void StopMovement()
    {
        if (!characterModel) return;

        characterModel.velocity = Vector2.zero;
        isMoving = false;
    }
}