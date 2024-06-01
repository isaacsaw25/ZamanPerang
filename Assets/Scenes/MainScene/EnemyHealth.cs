using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 50;
    public float delayTime = .15f;
    public Movement move;
    public GameObject popUpDamagePrefab;
    public TMP_Text popUpText;

    void Start()
    {
        health = maxHealth;
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        popUpText.text = damage.ToString();
        Instantiate(popUpDamagePrefab, transform.position, Quaternion.identity);
        StartCoroutine(knockbackDelay());
    }

    IEnumerator knockbackDelay()
    {
        move.enabled = false;
        yield return new WaitForSeconds(delayTime);
        if (health <= 0)
        {
            Destroy(gameObject);
        } else
        {
            move.enabled = true;
        }
    }
}
