using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public bool isFriendly;
    public GameObject unitPrefab;    // The unit prefab to be spawned
    public Button spawnButton;       // Button to trigger spawning (optional)

    void Start()
    {
        if (spawnButton != null)
        {
            // Add a listener to the button to spawn a unit when clicked
            spawnButton.onClick.AddListener(() => SpawnUnit(isFriendly));
        }
        gameObject.transform.position = new Vector3(isFriendly ? -6 : 6, -2, 0); // Set the spawner's position 
    }

    // Method to spawn a unit and configure its properties
    public void SpawnUnit(bool friendlyStatus)
    {
        if (unitPrefab == null)
        {
            Debug.LogError("Unit prefab is not assigned.");
            return;
        }

        // Instantiate the unit at the spawn point's position with no rotation
        GameObject unitInstance = Instantiate(unitPrefab, gameObject.transform.position, Quaternion.identity);

        // Access the CharacterAttack component on the spawned unit
        CharacterAttack characterAttack = unitInstance.GetComponent<CharacterAttack>();
        if (characterAttack != null)
        {
            // Set the isFriendly property based on the passed friendlyStatus parameter
            characterAttack.isFriendly = friendlyStatus;
            Debug.Log("Spawned unit " + unitInstance.name + " isFriendly: " + characterAttack.isFriendly);
        }
        else
        {
            Debug.LogWarning("CharacterAttack component not found on the spawned unit.");
        }
    }
}

