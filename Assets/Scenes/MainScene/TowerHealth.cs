using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 50;
    public Slider Slider;

    void Start()
    {
        health = maxHealth;
        Slider.maxValue = maxHealth;
    }

    void Update()
    {
        Slider.value = health;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
