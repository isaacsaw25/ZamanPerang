using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyDeploymentScript : MonoBehaviour
{
    public GameObject homeMenu;
    public GameObject deployMenu;
    public GameObject[] ages;
    public float[] experience; // experience levels to upgrade age
    public Rigidbody2D[] bases;
    public GameObject[] texts;
    private int currentAge = 0;


    // Start is called before the first frame update
    void Start()
    {
        homeMenu.SetActive(true);
        deployMenu.SetActive(false);

        activateAge();
        activateBase();
        activateHistory();
    }

    public void Prestige()
    {
        if (currentAge < 4 && CurrencyScript.experience >= experience[currentAge])
        {
            currentAge++;
        }

        activateAge();
        activateBase();
        activateHistory();

        if (currentAge > 0)
        {
            float previousCurrentHealth = bases[currentAge - 1].
                    gameObject.GetComponent<CharacterHealth>().currentHealth;
            float previousMaxHealth = bases[currentAge - 1].
                    gameObject.GetComponent<CharacterHealth>().maxHealth;

            float newMaxHealth = bases[currentAge].gameObject.GetComponent<CharacterHealth>().maxHealth;

            bases[currentAge].gameObject.GetComponent<CharacterHealth>()
                    .currentHealth = (int)(previousCurrentHealth / previousMaxHealth * newMaxHealth);
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
