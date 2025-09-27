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
        Vector3 oldPos = rb.position;
        Vector3 moveAhead = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * inputHorizontal * speed * Time.fixedDeltaTime * 2;
        Vector3 newPos = rb.position + moveAhead + horizontalMove;
        if (newPos.x <= -4.5 || newPos.x >= 4.5)
        {
            newPos.x = oldPos.x;
        }
        rb.MovePosition(newPos);
    }

    private void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
    }
}
