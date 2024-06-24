using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyDeploymentScript : MonoBehaviour
{
    public GameObject homeMenu;
    public GameObject deployMenu;
    public GameObject[] ages;
    private int currentAge = 0;

    // Start is called before the first frame update
    void Start()
    {
        homeMenu.SetActive(true);
        deployMenu.SetActive(false);

        foreach (var age in ages)
        {
            age.SetActive(false); // Set all other ages to inactive
        }
        ages[currentAge].SetActive(true); // Set first age to true
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Prestige()
    {
        if (currentAge < 4)
        {
            currentAge++;
        }
        foreach (var age in ages)
        {
            age.SetActive(false); // Set all other ages to inactive
        }
        ages[currentAge].SetActive(true); // Set first age to true
    }
}
