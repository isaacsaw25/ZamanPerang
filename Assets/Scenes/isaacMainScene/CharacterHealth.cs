using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    
    public Vector3 healthBarOffset = new Vector3(0, 1.2f, 0); // Offset for the health bar 
    public GameObject healthBarPrefab;
    private GameObject healthBarInstance;
    private Image healthFill;

    private CharacterAttack CharacterAttack;
    private GameObject mainGameLogic;
    private MainGameLogic logicScript;

    void Start()
    {
        currentHealth = maxHealth;
        CharacterAttack = GetComponent<CharacterAttack>();
        mainGameLogic = GameObject.Find("MainGameLogic");
        logicScript = mainGameLogic.GetComponent<MainGameLogic>();

        if (healthBarPrefab != null)
        {
            healthBarInstance = Instantiate(healthBarPrefab, transform.position, Quaternion.identity);
            healthFill = healthBarInstance.transform.Find("CurrentHealth").GetComponent<Image>();
            healthFill.fillAmount = currentHealth / maxHealth;
            healthBarInstance.SetActive(false);
        }
    }

    private void Update()
    {
        if (healthBarInstance != null)
        {
            // Update the position of the health bar with the offset applied
            healthBarInstance.transform.position = transform.position + healthBarOffset;

            // Update the health fill based on the current health
            if (healthFill != null)
            {
                healthFill.fillAmount = (float)currentHealth / (float)maxHealth;
            }
        }
    }
    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (healthFill != null)
        {
            healthFill.fillAmount = currentHealth / maxHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " died.");
        Destroy(healthBarInstance);
        Destroy(gameObject);
        if (!CharacterAttack.isFriendly && mainGameLogic != null) // Add currencies if character is enemy
        {
            logicScript.zpDollar += 25;
            logicScript.experience += 300;
        }
    }

    void OnMouseEnter()
    {
        if (healthBarInstance != null)
        {
            healthBarInstance.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        if (healthBarInstance != null)
        {
            healthBarInstance.SetActive(false);
        }
    }
}