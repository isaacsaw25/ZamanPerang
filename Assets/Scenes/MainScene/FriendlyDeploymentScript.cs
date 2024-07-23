using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyDeploymentScript : MonoBehaviour
{
    public GameObject homeMenu;
    public GameObject deployMenu;
    public GameObject[] ages;
    public Rigidbody2D[] bases;
    public GameObject[] texts;
    private int currentAge = 0;
    public GameObject MainController;
    public ExperienceScript experienceScript;


    // Start is called before the first frame update
    void Start()
    {
        homeMenu.SetActive(true);
        deployMenu.SetActive(false);
        experienceScript = MainController.GetComponent<ExperienceScript>();

        activateAge();
        activateBase();
        activateHistory();
    }

    public void Prestige()
    {
        if (currentAge < 4 && CurrencyScript.experience >= experienceScript.experience[currentAge])
        {
            // Upgrade to the next age
            currentAge++;

            // Activate the new age settings
            activateAge();
            activateBase();
            activateHistory();

            // Get previous base's health component
            CharacterHealth previousHealthComponent = bases[currentAge - 1].GetComponent<CharacterHealth>();
            if (previousHealthComponent == null)
            {
                Debug.LogError($"Previous health component is null for age {currentAge - 1}");
                return;
            }

            // Get the current base's health component for the new age
            CharacterHealth newHealthComponent = bases[currentAge].GetComponent<CharacterHealth>();
            if (newHealthComponent == null)
            {
                Debug.LogError($"New health component is null for age {currentAge}");
                return;
            }

            // Debugging: Print previous health values
            Debug.Log($"Previous Current Health: {previousHealthComponent.currentHealth}");
            Debug.Log($"Previous Max Health: {previousHealthComponent.maxHealth}");

            // Debugging: Print new max health value
            Debug.Log($"New Max Health: {newHealthComponent.maxHealth}");

            // Calculate the new current health based on the percentage of previous current health to max health
            float previousCurrentHealth = previousHealthComponent.currentHealth;
            float previousMaxHealth = previousHealthComponent.maxHealth;
            float newMaxHealth = newHealthComponent.maxHealth;

            // Preserve the health percentage when upgrading to the new age
            newHealthComponent.currentHealth = previousCurrentHealth / previousMaxHealth * newMaxHealth;

            // Debugging: Print new current health value
            Debug.Log($"New Current Health: {newHealthComponent.currentHealth}");
        }
        else
        {
            Debug.LogWarning($"Cannot prestige: Current age is {currentAge} or insufficient experience.");
        }
    }

    public void activateAge()
    {
        foreach (var age in ages)
        {
            age.SetActive(false); // Set all other ages to inactive
        }
        ages[currentAge].SetActive(true); // Set first age to true
    }

    public void activateBase()
    {
        foreach (var b in bases)
        {
            b.gameObject.SetActive(false);
        }
        bases[currentAge].gameObject.SetActive(true);
    }

    public void activateHistory()
    {
        foreach (var t in texts)
        {
            t.gameObject.SetActive(false);
        }
        texts[currentAge].gameObject.SetActive(true);
    }
    public int getCurrentAge() 
    { 
        return currentAge; 
    }
}
