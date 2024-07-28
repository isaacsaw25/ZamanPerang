using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretDeployment : MonoBehaviour
{
    public int currentAge = 0;
    public GameObject[] turretTowers; // Array to store turret tower prefabs for each age
    public GameObject[] turrets; // Array to store turret prefabs for each age
    public GameObject[] turretDeploymentSpots; // Array to store deployment spots for turrets
    public GameObject[] turretsSpots;
    public int numOfTurretSpots = 0;
    public int numOfTurrets = 0;
    public List<GameObject> turretStorage = new List<GameObject>(); // List to store deployed turrets
    public List<GameObject> turretsTowerStorage = new List<GameObject>(); // List to store deployed turret towers
    public GameObject MainController;
    public CurrencyScript currencyScript;
    public ExperienceScript experienceScript;
    public float[] spotCost = { 1000, 5000, 25000 };

    void Start()
    {
        currencyScript = MainController.GetComponent<CurrencyScript>();
        experienceScript = MainController.GetComponent<ExperienceScript>();
        // Initialize the currencyScript reference
        if (currencyScript == null)
        {
            Debug.LogError("CurrencyScript component not found on MainController.");
        }
    }

    public void updateAge()
    {
        if (currentAge < 4 && CurrencyScript.experience >= experienceScript.experience[currentAge]) // need insert experience logic
        {
            currentAge++;

            foreach (GameObject tower in turretsTowerStorage)
            {
                Destroy(tower);
            }

            turretsTowerStorage.Clear();

            // Rebuild new age towers
            for (int i = 0; i < numOfTurretSpots; i++)
            {
                GameObject turretTowerInstance = Instantiate(turretTowers[currentAge], turretDeploymentSpots[i].transform.position,
                            Quaternion.identity);

                Vector3 newScale = new Vector3(0.5f, 0.5f, 0.5f);
                turretTowerInstance.transform.localScale = newScale;

                // Add piece of Tower into Storage array
                turretsTowerStorage.Add(turretTowerInstance);
            }
        }
        else
        {
            Debug.Log("Already at the maximum age.");
        }
    }

    public void buildTurretSpot()
    {
        if (numOfTurretSpots < turretDeploymentSpots.Length)
        {
            // Check if cost of the spot is met
            CharacterCurrency characterCurrency = turretTowers[currentAge].GetComponent<CharacterCurrency>();
            float cost = spotCost[numOfTurretSpots];

            if (CurrencyScript.zpDollar >= cost)
            {
                // Instantiate the unit at the spawn point's position with no rotation
                GameObject turretTowerInstance = Instantiate(turretTowers[currentAge], turretDeploymentSpots[numOfTurretSpots].transform.position,
                        Quaternion.identity);

                Vector3 newScale = new Vector3(0.5f, 0.5f, 0.5f);
                turretTowerInstance.transform.localScale = newScale;

                // Add piece of Tower into Storage array
                turretsTowerStorage.Add(turretTowerInstance);

                // Remove deploy cost from the player
                CurrencyScript.zpDollar -= cost;

                // Update the number of turretSpots
                numOfTurretSpots++;
            }
            else
            {
                Debug.Log("Not enough ZP$ to deploy " + turretTowers[currentAge].name);
            }
        }
        else
        {
            Debug.Log("Maximum number of turret spots reached.");
        }
    }

    public void buildTurret()
    {
        if (numOfTurretSpots > numOfTurrets && numOfTurrets < turretDeploymentSpots.Length)
        {
            // Check if cost of the spot is met
            CharacterCurrency characterCurrency = turrets[currentAge].GetComponent<CharacterCurrency>();
            float cost = characterCurrency.deployCost;

            if (CurrencyScript.zpDollar >= cost)
            {
                // Instantiate the unit at the spawn point's position with no rotation
                GameObject turretInstance = Instantiate(turrets[currentAge], turretsTowerStorage[numOfTurrets].transform.position,
                        turretsTowerStorage[numOfTurrets].transform.rotation);

                // Add turret into Storage array
                turretStorage.Add(turretInstance);

                // Remove deploy cost from the player
                CurrencyScript.zpDollar -= cost;

                // Update the number of turretSpots
                numOfTurrets++;
            }
            else
            {
                Debug.Log("Not enough ZP$ to deploy or not enough tower spots " + turrets[currentAge].name);
            }
        }
        else
        {
            Debug.Log("No available turret spots or maximum number of turrets reached.");
        }
    }

    public void sellTurret()
    {
        if (numOfTurrets > 0)
        {
            GameObject turretToDestroy = turretStorage[numOfTurrets - 1];
            CharacterCurrency characterCurrency = turretToDestroy.GetComponent<CharacterCurrency>();
            float cost = characterCurrency.sellCost;

            // Add sell cost to the player
            CurrencyScript.zpDollar += cost;

            // Remove turret from storage
            turretStorage.Remove(turretToDestroy);

            // Destroy the turret
            Destroy(turretToDestroy);

            // Update the number of turrets
            numOfTurrets--;
        }
        else
        {
            Debug.Log("No turrets to sell.");
        }
    }
}