using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    void FixedUpdate()
    {
        rb.velocity = Vector2.left * speed;
    }
}
