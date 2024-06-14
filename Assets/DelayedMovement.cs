using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedMovement : MonoBehaviour
{
    public float detectionRadius = 0.5f;   // Radius to detect other units in the vicinity
    public float moveDelay = 1f;           // Delay before the unit starts moving
    private CharacterMovement characterMovement;
    private bool isFriendly;
    private Vector3 spawnPoint;

    public void Initialize(bool friendly, Vector3 spawnPt)
    {
        isFriendly = friendly;
        spawnPoint = spawnPt;

        // Get the CharacterMovement component on this unit
        characterMovement = GetComponent<CharacterMovement>();

        if (characterMovement != null)
        {
            // Start the delayed movement logic
            StartCoroutine(CheckAndMoveAfterDelay());
        }
    }

    private IEnumerator CheckAndMoveAfterDelay()
    {
        // Disable movement initially
        characterMovement.freeze = true;

        // Detect units within the radius around the spawn point
        Collider2D[] nearbyUnits;
        do
        {
            nearbyUnits = Physics2D.OverlapCircleAll(spawnPoint, detectionRadius);
            yield return new WaitForSeconds(moveDelay); // Wait before checking again
        }
        while (nearbyUnits.Length > 1); // Keep delaying while there are multiple units detected

        // Enable movement after the delay if no other units are too close
        characterMovement.freeze = false;
    }
}
