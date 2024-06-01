using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public float spawnTime = 2;
    private float timer;
    private int currentEnemy;

    void Start()
    {
        timer = spawnTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {

        Instantiate(enemyPrefab[currentEnemy], transform.position, Quaternion.identity);
        currentEnemy++;
        if (currentEnemy >= enemyPrefab.Length)
        {
            this.enabled = false;
        }
        timer = spawnTime;
    }
}
