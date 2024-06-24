using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public bool isFriendly;
    public GameObject[] unitPrefabs; // Array to hold unit prefabs
    public Button[] spawnButtons;    // Array to hold spawn buttons
    public Transform spawnPoint;     // Spawn point for the units

    void Start()
    {
        // Check if the arrays are set up correctly
        if (unitPrefabs.Length != spawnButtons.Length)
        {
            Debug.LogError("The number of unit prefabs does not match the number of spawn buttons.");
            return;
        }

        // Assign listeners to each button
        for (int i = 0; i < spawnButtons.Length; i++)
        {
            int index = i; // Local copy of the loop variable for the closure
            if (spawnButtons[i] != null)
            {
                spawnButtons[i].onClick.AddListener(() => SpawnUnit(index));
            }
            else
            {
                Debug.LogWarning("Spawn button at index " + i + " is not assigned.");
            }
        }

        // Set spawn point to transform of spawner
        spawnPoint = gameObject.transform;
    }

    // Method to spawn a unit based on the index
    public void SpawnUnit(int unitIndex)
    {
        if (unitIndex < 0 || unitIndex >= unitPrefabs.Length)
        {
            Debug.LogError("Invalid unit index: " + unitIndex);
            return;
        }

        if (unitPrefabs[unitIndex] == null)
        {
            Debug.LogError("Unit prefab at index " + unitIndex + " is not assigned.");
            return;
        }

        // Instantiate the unit at the spawn point's position with no rotation
        GameObject unitInstance = Instantiate(unitPrefabs[unitIndex], spawnPoint.position, Quaternion.identity);

        // Access the CharacterAttack component on the spawned unit
        CharacterAttack characterAttack = unitInstance.GetComponent<CharacterAttack>();
        if (characterAttack != null)
        {
            // Set the isFriendly property based on the isFriendly status of the spawner
            characterAttack.isFriendly = isFriendly;
            Debug.Log("Spawned unit " + unitInstance.name + " isFriendly: " + characterAttack.isFriendly);
        }
        else
        {
            Debug.LogWarning("CharacterAttack component not found on the spawned unit.");
        }
    }
}
