using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseScript : MonoBehaviour
{
    private float maxHealth;
    private float currentHealth;
    private bool isFriendly = true;
    public Image CurrentHealth;
    public GameObject HealthDisplay;

    private TextMeshProUGUI HealthValue;

    void Start()
    {
        maxHealth = gameObject.GetComponent<CharacterHealth>().maxHealth;
        isFriendly = gameObject.GetComponent<CharacterHealth>().isFriendly;
        HealthValue = HealthDisplay.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        currentHealth = gameObject.GetComponent<CharacterHealth>().currentHealth;

        CurrentHealth.fillAmount = (float)currentHealth / (float)maxHealth;

        HealthValue.text = currentHealth.ToString();

        if (currentHealth <= 0)
        {
            PlayerPrefs.SetInt("winState", isFriendly ? 0 : 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameEndScene");
        }
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(isFriendly ? "Friendly" : "Enemy" + " base took damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        { 
            SceneManager.LoadScene("GameEndScene");
        }
    }
}
