using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealths : MonoBehaviour
{
    public Image friendlyBaseFill;
    public Image enemyBaseFill;
    public GameObject friendlyHealthDisplay;
    public GameObject enemyHealthDisplay;

    public float friendlyBaseMaxHealth = 500;
    public float friendlyBaseCurrentHealth;
    public float enemyBaseMaxHealth = 500;
    public float enemyBaseCurrentHealth;


    // Start is called before the first frame update
    void Start()
    {
        // Set the healths of both bases to max health
        friendlyBaseCurrentHealth = friendlyBaseMaxHealth;
        enemyBaseCurrentHealth = enemyBaseMaxHealth;


    }

    // Update is called once per frame
    void Update()
    {
        friendlyBaseFill.fillAmount = (float)friendlyBaseCurrentHealth / (float)friendlyBaseMaxHealth;
        enemyBaseFill.fillAmount = (float)(enemyBaseCurrentHealth / (float)enemyBaseMaxHealth);

        friendlyHealthDisplay.GetComponent<TextMeshProUGUI>().text = friendlyBaseCurrentHealth.ToString();
        enemyHealthDisplay.GetComponent<TextMeshProUGUI>().text = enemyBaseCurrentHealth.ToString();
    }
}
