using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyStateMachine : MonoBehaviour
{
    public FriendlyState friendlyState;
    public float detectionRange = 6;
    public LayerMask enemyLayer;
    public MovementFriendly movementFriendly;
    public Gun gun;
    void Start()
    {
        friendlyState = FriendlyState.Walking;
        gun.enabled = false;
    }

    void Update()
    {
        if (friendlyState == FriendlyState.Walking)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, detectionRange);
            if (hit.collider != null)
            {
                friendlyState = FriendlyState.Shooting;
                gun.enabled = true;
                movementFriendly.enabled = false;
            }
        }
    }
}

public enum FriendlyState
{
    Idle,
    Walking,
    Shooting
}
