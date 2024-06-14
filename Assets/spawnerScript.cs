using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public bool isFriendly;
    public GameObject unitPrefab;   // The unit prefab to be spawned
    public Vector3 spawnPoint;      // The location where the unit will be spawned
    public Button spawnButton;      // Button to trigger spawning 
    public float moveDelay = 1f;    // Delay before each unit starts moving
    public float moveSpeed = 2f;    // Speed at which the units move

    private Queue<GameObject> unitQueue = new Queue<GameObject>(); // Queue to manage unit movement

    void Start()
    {
        if (isFriendly)
        {
            spawnPoint = new Vector3(-5.5f, -2f, 0);
        }
        else
        {
            spawnPoint = new Vector3(5.5f, -2f, 0);
        }

        if (spawnButton != null)
        {
            // Add a listener to the button to spawn a unit when clicked
            spawnButton.onClick.AddListener(() => SpawnUnit(isFriendly));
        }
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
        GameObject unitInstance = Instantiate(unitPrefab, spawnPoint, Quaternion.identity);

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

        // Add the unit to the movement queue
        unitQueue.Enqueue(unitInstance);

        // Start processing the queue if it's not already being processed
        if (unitQueue.Count == 1)
        {
            StartCoroutine(ProcessQueue());
        }
    }

    // Coroutine to process the unit queue and move units one by one
    private IEnumerator ProcessQueue()
    {
        while (unitQueue.Count > 0)
        {
            GameObject unit = unitQueue.Peek(); // Get the unit at the front of the queue

            // Move the unit to the right direction
            MoveUnit(unit);

            // Wait for the specified delay before moving the next unit
            yield return new WaitForSeconds(moveDelay);

            // Remove the unit from the queue after it starts moving
            unitQueue.Dequeue();
        }
    }

    // Method to move a unit in the specified direction
    private void MoveUnit(GameObject unit)
    {
        // Start a coroutine to move the unit smoothly
        StartCoroutine(MoveUnitCoroutine(unit));
    }

    // Coroutine to handle the smooth movement of a unit
    private IEnumerator MoveUnitCoroutine(GameObject unit)
    {
        // Get the direction based on whether the unit is friendly
        Vector3 direction = isFriendly ? Vector3.right : Vector3.left;

        // Move the unit continuously
        while (unit != null)
        {
            unit.transform.Translate(direction * moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
