using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D bullet;
    public float speed = 2.5f;
    public float range = 1f;
    private float timer;
    public int damage = 20;
    public float knockbackForce = 5;

    private void Start()
    {
        timer = range;
    }
    void FixedUpdate()
    {
        bullet.velocity = Vector2.right * speed;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHealth>())
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * knockbackForce, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<EnemyHealth>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
