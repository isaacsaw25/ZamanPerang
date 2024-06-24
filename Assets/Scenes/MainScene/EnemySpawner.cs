using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] troopPrefabs;  // Array of troop prefabs
    public TMP_InputField troopIDInputField;  // Reference to the InputField
    public Button spawnButton;  // Reference to the Button

    void Start()
    {
        // Add a listener to the button to call the SpawnTroop method when clicked
        spawnButton.onClick.AddListener(SpawnTroop);

        //InputField = troopIDInputField.GetComponent<InputField>();
    }

    void SpawnTroop()
    {
        // Get the input text from the InputField
        string input = troopIDInputField.text;

        // Try to parse the input text as an integer
        if (int.TryParse(input, out int troopID))
        {
            // Check if the troopID is within the range of available prefabs
            if (troopID >= 0 && troopID < troopPrefabs.Length)
            {
                // Instantiate the selected troop at the spawner's position
                GameObject spawnedTroop = Instantiate(troopPrefabs[troopID], transform.position, Quaternion.identity);

                // Set isFriendly to false
                CharacterAttack characterAttack = spawnedTroop.GetComponent<CharacterAttack>();
                if (characterAttack != null)
                {
                    characterAttack.isFriendly = false;
                }
                else
                {
                    Debug.LogError("The spawned troop does not have a CharacterAttack component.");
                }
            }
            else
            {
                Debug.LogError("Invalid troop ID.");
            }
        }
        else
        {
            Debug.LogError("Invalid input. Please enter a number.");
        }
    }
}
