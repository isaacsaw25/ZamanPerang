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

    public void newImage()
    {
        if (currentAge < 4)
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
            Instantiate(planePrefab, spawnPointAge1.position, spawnPointAge1.rotation);
        }
    }
}
