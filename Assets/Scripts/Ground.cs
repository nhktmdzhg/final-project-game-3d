using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    GroundController groundController;
    private float paddingUp = 0.35f;

    // Start is called before the first frame update
    private void Start()
    {
        groundController = GameObject.FindObjectOfType<GroundController>();
        //SpawnObstacle();
        //SpawnCoin();
    }
    private void OnTriggerExit(Collider other)
    {
        groundController.SpawnGround(true);
        Destroy(gameObject, 2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] GameObject obstaclePrefab1;
    [SerializeField] GameObject obstaclePrefab2;
    public void SpawnObstacle()
    {
        int randomIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(randomIndex).transform;

        GameObject prefabToSpawn = Random.Range(0, 2) == 0 ? obstaclePrefab1 : obstaclePrefab2;

        Vector3 spawnPosition = spawnPoint.position;
        if (prefabToSpawn == obstaclePrefab2)
        {
            spawnPosition.y += paddingUp;
        }
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity, transform);
    }

    [SerializeField] GameObject coinPrefab;
    public void SpawnCoin()
    {
        int randomCoinToSpawn = Random.Range(2, 13);
        int maxChildren = transform.childCount;

        for (int i = 0; i < randomCoinToSpawn && i < maxChildren; i++)
        {
            Transform spawnPoint = transform.GetChild(i).transform;
            GameObject temp = Instantiate(coinPrefab);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }
        point.y = 1;
        return point;
    }

}
