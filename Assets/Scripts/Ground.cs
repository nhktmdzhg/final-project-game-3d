using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    GroundController groundController;

    // Start is called before the first frame update
    private void Start()
    {
        groundController = GameObject.FindObjectOfType<GroundController>();
        SpawnObstacle();
    }
    private void OnTriggerExit(Collider other)
    {
        groundController.SpawnGround();
        Destroy(gameObject, 2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obstaclePrefab;
    public void SpawnObstacle()
    {
        int randomIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(randomIndex).transform;
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
}
