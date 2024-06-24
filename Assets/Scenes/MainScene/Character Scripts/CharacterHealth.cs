using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public bool isFriendly;
    public bool isBase = false;
    public float moneyDropped = 25; // ZP$ gained when defeating enemy troop
    public float expDropped = 200; // EXP gained when defeating enemy troop

    public Vector3 healthBarOffset = new Vector3(0, 1.2f, 0); // Offset for the health bar 
    public GameObject healthBarPrefab;
    public GameObject popUpTextPrefab;
    private GameObject healthBarInstance;
    private Image healthFill;

    private CharacterAttack CharacterAttack;
    public float difficultyMultiplier;
    private GameObject mainController;
    private CurrencyScript currencyScript;

    void Start()
    {
        difficultyMultiplier = PlayerPrefs.GetFloat("DifficultyMultiplier", 1.0f);

        CharacterAttack = GetComponent<CharacterAttack>();
        if (CharacterAttack != null )
        {
            isFriendly = CharacterAttack.isFriendly;
        }

        if (!isFriendly && !isBase) // inject the difficulty level into enemy units
        {
            maxHealth *= difficultyMultiplier;
        }

        currentHealth = maxHealth;
        mainController = GameObject.Find("MainLogicController");
        currencyScript = mainController.GetComponent<CurrencyScript>();

        if (healthBarPrefab != null && !isBase) // Set up heathbar if chracter is not the base
        {
            healthBarInstance = Instantiate(healthBarPrefab, transform.position, Quaternion.identity);
            healthFill = healthBarInstance.transform.Find("CurrentHealth").GetComponent<Image>();
            healthFill.fillAmount = currentHealth / maxHealth;
            healthBarInstance.SetActive(false);
        }
    }

    private void Update()
    {
        if (healthBarInstance != null && !isBase)
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
        if (!isBase)
        {
            Debug.Log(gameObject.name + " died.");
            if (!isFriendly && mainController != null) // Add currencies if character is enemy
            {
                currencyScript.zpDollar += moneyDropped;
                currencyScript.experience += expDropped;
                // Instantiate money pop up based on value
                GameObject popup = Instantiate(popUpTextPrefab, gameObject.transform.position + healthBarOffset, Quaternion.identity);
                Destroy(popup, 1.5f); // Destory the popup after delay
                PopUpTextController popupController = popup.GetComponentInChildren<PopUpTextController>(); 
                if (popupController != null)
                {
                    popupController.SetText("+$" + moneyDropped);
                }
                else
                {
                    Debug.LogWarning("MoneyPopupController component not found on the moneyPopupPrefab.");
                }
            }
            Destroy(healthBarInstance);
            Destroy(gameObject);
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