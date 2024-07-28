using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Enemy_AI : MonoBehaviour
{
    /*
    RULES FOR THE ENEMY AI EXTRACTED FROM ACTIONSCRIPT CODE:
    no more than 6 enemies on the map
    30% change of spawning troops each second
    units have to train just like player units
    For each age:
    after first 1500 frames the 2nd tier troops become available
    after first 5000 frames the 3nd tier troops become available
    after first 8000 frames it will upgrade it s age
    the troop type is randomized
    the turret buying follow a fixed succesion in each game
    Age1:
    1000 -> turret1 slot1
    4000 -> sell slot1 ,turret2 slot1
    6000 -> sell slot1 ,turret3 slot1
    Age2:
    1000 -> sell slot1 ,turret1 slot1
    4000 -> buy slot, sell slot1 ,turret3 slot1
    6000 -> turret2 slot2
    Age3:
    1000 -> sell slot1, turret1 slot1
    4000 -> buy slot, sell slot2, turret1 slot2
    6000 -> sell slot1, sell slot2, turret3 slot3
    Age4:
    5000 -> turret1 slot 1
    7000 -> sell slot1 sell slot3, turret2 slot2
    Age5:
    5000 -> turret1 slot1
    12000 -> sell slot1, sell slot2, sell slot3, turret2 slot 2
    20000 -> buy slot, sell all slots, turret3 slot 4
     */

    public int currentAge = 0;
    public GameObject[] turretTowers; // Array to store turret tower prefabs for each age
    public GameObject[] turrets; // Array to store turret prefabs for each age
    public GameObject[] turretDeploymentSpots; // Array to store deployment spots for turrets
    public List<GameObject> turretStorage = new List<GameObject>(); // List to store deployed turrets
    public List<GameObject> turretsTowerStorage = new List<GameObject>(); // List to store deployed turret towers
    public List<GameObject> currentUnits = new List<GameObject>(); // List to store deployed turret towers

    public GameObject[] enemyBases;
    public GameObject[] unitPrefabs;
    public GameObject[] age1unitPrefabs;
    public GameObject[] age2unitPrefabs;
    public GameObject[] age3unitPrefabs;
    public GameObject[] age4unitPrefabs;
    public GameObject[] age5unitPrefabs;
    public Transform spawnPoint;     // Spawn point for the units
    public int unit_level = 0;

    public void Protocol_age1()
    {
        unit_level = 0;
        StartCoroutine(upgrade_unity_level(30));
        StartCoroutine(upgrade_unity_level(100));
        StartCoroutine(upgrade_age(160));

        StartCoroutine(buy_turret(80, 0)); // create age1 turret after 4000 frames 
    }
    public void Protocol_age2()
    {
        unit_level = 0;
        StartCoroutine(upgrade_unity_level(30));
        StartCoroutine(upgrade_unity_level(100));
        StartCoroutine(upgrade_age(160));

        StartCoroutine(sell_turret(90, 0)); // sell age1 turret at first slot
        StartCoroutine(buy_turret(95, 0)); // create age2 turret at first slot

        StartCoroutine(buy_turret(150, 1)); // create age2 turret at second slot
    }
    public void Protocol_age3()
    {

        unit_level = 0;
        StartCoroutine(upgrade_unity_level(30));
        StartCoroutine(upgrade_unity_level(100));
        StartCoroutine(upgrade_age(160));

        StartCoroutine(sell_turret(90, 0)); // sell age2 turret at first slot
        StartCoroutine(buy_turret(95, 0)); // create age3 turret at first slot

        StartCoroutine(sell_turret(140, 1)); // sell age2 turret at second slot
        StartCoroutine(buy_turret(145, 1)); // create age3 turret at second slot

    }
    public void Protocol_age4()
    {
        unit_level = 0;
        StartCoroutine(upgrade_unity_level(30));
        StartCoroutine(upgrade_unity_level(100));
        StartCoroutine(upgrade_age(160));

        StartCoroutine(sell_turret(90, 0)); // sell age3 turret at first slot
        StartCoroutine(buy_turret(95, 0)); // create age4 turret at first slot

        StartCoroutine(sell_turret(140, 1)); // sell age3 turret at second slot
        StartCoroutine(buy_turret(145, 1)); // create age4 turret at second slot
    }
    public void Protocol_age5()
    {
        unit_level = 0;
        StartCoroutine(upgrade_unity_level(30));
        StartCoroutine(upgrade_unity_level(100));
        StartCoroutine(upgrade_unity_level(300));

        StartCoroutine(sell_turret(240, 0)); // sell age4 turret at first slot
        StartCoroutine(buy_turret(245, 0)); // create age5 turret at first slot

        StartCoroutine(sell_turret(400, 1)); // sell age4 turret at second slot
        StartCoroutine(buy_turret(405, 1)); // create age5 turret at second slot

        StartCoroutine(buy_turret(700, 2)); // create age5 turret at third slot
    }


    void Start()
    {
        StartCoroutine(Spawn_troops());
        Protocol_age1();
        unitPrefabs = age1unitPrefabs;

        foreach (var b in enemyBases)
        {
            b.SetActive(false); // Set all other ages to inactive
        }
        enemyBases[currentAge].SetActive(true); // Set first age to true

        for (int i = 0; i < 3; i++)
        {
            GameObject turretTowerInstance = Instantiate(turretTowers[currentAge], turretDeploymentSpots[i].transform.position,
                        Quaternion.identity);

            Vector3 newScale = new Vector3(0.5f, 0.5f, 0.5f);
            turretTowerInstance.transform.localScale = newScale;
            // Add piece of Tower into Storage array
            turretsTowerStorage.Add(turretTowerInstance);
        }
    }

    IEnumerator upgrade_age(int frames)
    {
        yield return new WaitForSeconds(frames /* game_manager.data_object.FPS */);

        currentAge++;

        // change base
        foreach (var b in enemyBases)
        {
            b.SetActive(false); // Set all other ages to inactive
        }
        enemyBases[currentAge].SetActive(true); // Set first age to true

        // change towers
        foreach (GameObject tower in turretsTowerStorage)
        {
            Destroy(tower);
        }

        turretsTowerStorage.Clear();

        for (int i = 0; i < 3; i++)
        {
            GameObject turretTowerInstance = Instantiate(turretTowers[currentAge], turretDeploymentSpots[i].transform.position,
                        Quaternion.identity);

            Vector3 newScale = new Vector3(0.5f, 0.5f, 0.5f);
            turretTowerInstance.transform.localScale = newScale;
            // Add piece of Tower into Storage array
            turretsTowerStorage.Add(turretTowerInstance);
        }

        float previousCurrentHealth = enemyBases[currentAge - 1].
                    gameObject.GetComponent<CharacterHealth>().currentHealth;
        float previousMaxHealth = enemyBases[currentAge - 1].
                gameObject.GetComponent<CharacterHealth>().maxHealth;

        float newMaxHealth = enemyBases[currentAge].gameObject.GetComponent<CharacterHealth>().maxHealth;

        enemyBases[currentAge].gameObject.GetComponent<CharacterHealth>()
                .currentHealth = (int)(previousCurrentHealth / previousMaxHealth * newMaxHealth);

        if (currentAge == 1)
        {
            Protocol_age2();
            unitPrefabs = age2unitPrefabs;
        }
        if (currentAge == 2)
        {
            Protocol_age3();
            unitPrefabs = age3unitPrefabs;
        }
        if (currentAge == 3)
        {
            Protocol_age4();
            unitPrefabs = age4unitPrefabs;
        }
        if (currentAge == 4)
        {
            Protocol_age5();
            unitPrefabs = age5unitPrefabs;
        }

    }
    IEnumerator upgrade_unity_level(int frames)
    {

        yield return new WaitForSeconds(frames /* game_manager.data_object.FPS */);
        unit_level += 1;
    }

    IEnumerator sell_turret(int frames, int slot)
    {
        yield return new WaitForSeconds(frames /* game_manager.data_object.FPS */);

        GameObject turretToDestroy = turretStorage[slot];

        // Remove turret from storage
        turretStorage.Remove(turretToDestroy);

        // Destroy the turret
        Destroy(turretToDestroy);
    }

    IEnumerator buy_turret(int frames, int slot)
    {
        yield return new WaitForSeconds(frames /* game_manager.data_object.FPS */);

        GameObject turretInstance = Instantiate(turrets[currentAge], turretsTowerStorage[slot].transform.position,
                        Quaternion.identity);

        // Add turret into Storage array
        turretStorage.Add(turretInstance);
    }

    IEnumerator Spawn_troops()
    {
        yield return new WaitForSeconds(0.5f);
        float spawn = Random.Range(0f, 0.5f);
        if (spawn < 0.3f)
        {
            //print("spawned");
            int unit_type = Random.Range(0, unit_level + 1);
            GameObject unit = Instantiate(unitPrefabs[unit_type], spawnPoint.position, Quaternion.identity);
            currentUnits.Add(unit);
        }
        else
        {
            /*print(game_manager.enemy_troops_queue.Count );
            print(spawn);
            print("\n");*/
        }

        StartCoroutine(Spawn_troops());
    }
}
