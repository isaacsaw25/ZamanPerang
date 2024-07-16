using UnityEngine;
using System.Collections;

public class PlaneScript : MonoBehaviour
{
    public GameObject bombPrefab; // Assign the bomb prefab in the Inspector
    public float bombDropInterval = 2.0f; // Interval between bomb drops
    public float speed = 2.0f; // Speed of the plane
    public Vector3 endPoint; // The point where the plane will destroy itself

    private bool movingToEnd = true;

    public void Start()
    {
        StartCoroutine(DropBombs());
    }

    public void Update()
    {
        MoveTowardsEndPoint();
    }

    IEnumerator DropBombs()
    {
        while (true)
        {
            Instantiate(bombPrefab, gameObject.transform.position, gameObject.transform.rotation);
            yield return new WaitForSeconds(bombDropInterval);
        }
    }

    public void MoveTowardsEndPoint()
    {
        if (movingToEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint, speed * Time.deltaTime);
            if (transform.position == endPoint)
            {
                Destroy(gameObject);
            }
        }
    }
}