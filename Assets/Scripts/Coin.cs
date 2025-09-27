using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] float floatSpeed = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            return;
        }
        GameManager.instance.IncrementCoin();
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        //transform.Translate(0, floatSpeed * Time.deltaTime, 0);
    }
}
