using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    public GameObject soldier;
    public Transform spawnPoint;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SpawnSoldier()
    {
        Instantiate(soldier, spawnPoint.position, Quaternion.identity);
    }
}
