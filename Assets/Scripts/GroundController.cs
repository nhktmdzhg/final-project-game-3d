using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPosition;

    public void SpawnGround (bool spawnObject)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPosition, Quaternion.identity);
        nextSpawnPosition = temp.transform.GetChild(1).transform.position;

        if (spawnObject)
        {
            temp.GetComponent<Ground>().SpawnObstacle();
            temp.GetComponent<Ground>().SpawnCoin();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            if (i < 1)
            {
                SpawnGround(false);
            }
            else
            {
                SpawnGround(true);
            }
            
        }
    }
    
}
