using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpecial : MonoBehaviour
{
    public Sprite[] sprites;
    public int currentAge = 0;
    public Button specialButton;
    public GameObject lionBullet;
    public Transform spawnPointAge0;
    public GameObject planePrefab;
    public Transform spawnPointAge1;
    public GameObject MainController;
    public ExperienceScript experienceScript;
    public GameObject[] ballSpawner;
    public GameObject cannonball;
    public GameObject ionray;
    public BoostFriendlyUnits boost;

    public void Start()
    {
        experienceScript = MainController.GetComponent<ExperienceScript>();
    }
        
    public void newImage()
    {
        if (currentAge < 4 && CurrencyScript.experience >= experienceScript.experience[currentAge])
        {
            currentAge++;
        }
        specialButton.image.sprite = sprites[currentAge]; // changes image on special button
    }

    public void initiateSpecial()
    {
        if (currentAge == 0)
        {
            Instantiate(lionBullet, spawnPointAge0.position, spawnPointAge0.rotation); // create Lion Bullet
        }
        if (currentAge == 1)
        {
            foreach (GameObject s in ballSpawner)
            {
                Instantiate(cannonball, spawnPointAge1.position, Quaternion.identity);
            }
        }
        if (currentAge == 2)
        {
            Instantiate(planePrefab, spawnPointAge1.position, spawnPointAge1.rotation);
        }
        if (currentAge == 3)
        {
            boost = MainController.GetComponent<BoostFriendlyUnits>();
            boost.Activate();
        }
        if (currentAge == 4)
        {
            Instantiate(ionray, spawnPointAge0.position, spawnPointAge0.rotation); 
        }
    }
}
