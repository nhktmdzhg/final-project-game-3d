using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPosition;

    public void SpawnGround ()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPosition, Quaternion.identity);
        nextSpawnPosition = temp.transform.GetChild(1).transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            SpawnGround();
        }
    }
    
}
