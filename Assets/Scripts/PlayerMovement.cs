using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;

    void FixedUpdate()
    {
        Vector3 moveAhead = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveAhead);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
