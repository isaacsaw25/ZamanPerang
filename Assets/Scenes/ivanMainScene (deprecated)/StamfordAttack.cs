using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StamfordAttack : MonoBehaviour
{
    public int damage = 25;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TowerHealth>()) 
        {
            collision.gameObject.GetComponent<TowerHealth>().health -= damage;
            Destroy(gameObject); 
        }
    }
}
