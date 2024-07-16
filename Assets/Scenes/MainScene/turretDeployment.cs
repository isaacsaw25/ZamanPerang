using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretDeployment : MonoBehaviour
{
    public int currentAge = 0;
    public GameObject[] turretTowers; // Array to store turret tower prefabs for each age
    public GameObject[] turrets; // Array to store turret prefabs for each age
    public GameObject[] turretDeploymentSpots; // Array to store deployment spots for turrets
    public int numOfTurretSpots = 0;
    public int numOfTurrets = 0;
    public List<GameObject> turretStorage = new List<GameObject>(); // List to store deployed turrets
    public List<GameObject> turretsTowerStorage = new List<GameObject>(); // List to store deployed turret towers
    public GameObject MainController;
    public CurrencyScript currencyScript;
    public float[] experience;

    void Start()
    {
        currencyScript = MainController.GetComponent<CurrencyScript>();
        // Initialize the currencyScript reference
        if (currencyScript == null)
        {
            Debug.LogError("CurrencyScript component not found on MainController.");
        }
    }

    public void updateAge()
    {
        if (currentAge < turretTowers.Length - 1 && CurrencyScript.experience >= experience[currentAge]) // need insert experience logic
        {
            currentAge++;
        }
        else
        {
            Debug.Log("Already at the maximum age.");
        }

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
            // Add piece of Tower into Storage array
            turretsTowerStorage.Add(turretTowerInstance);
        }
    }

    public void buildTurretSpot()
    {
        if (numOfTurretSpots < turretDeploymentSpots.Length)
        {
            // Check if cost of the spot is met
            CharacterCurrency characterCurrency = turretTowers[currentAge].GetComponent<CharacterCurrency>();
            float cost = characterCurrency.deployCost;

            if (CurrencyScript.zpDollar >= cost)
            {
                // Instantiate the unit at the spawn point's position with no rotation
                GameObject turretTowerInstance = Instantiate(turretTowers[currentAge], turretDeploymentSpots[numOfTurretSpots].transform.position,
                        Quaternion.identity);

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
                GameObject turretInstance = Instantiate(turrets[currentAge], turretDeploymentSpots[numOfTurrets].transform.position,
                        Quaternion.identity);

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