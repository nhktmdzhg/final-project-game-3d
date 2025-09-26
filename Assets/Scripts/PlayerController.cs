using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;
    float inputHorizontal;

    private void FixedUpdate()
    {
        Vector3 moveAhead = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * inputHorizontal * speed * Time.fixedDeltaTime * 2;
        rb.MovePosition(rb.position + moveAhead + horizontalMove);
    }

    private void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
    }
}
