using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float coolDown = 2.5f;
    public float timer;
    void Start()
    {
        timer = coolDown;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            timer = coolDown;
        }
    }
}
