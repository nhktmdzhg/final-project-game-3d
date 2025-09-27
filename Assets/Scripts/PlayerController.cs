using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    private readonly float horizontalSpeed = 5;
    public Rigidbody rb;
    float inputHorizontal;
    private bool alive = true;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!alive)
        {
            anim.SetBool("isDead", true);
            return;
        }
        inputHorizontal = Input.GetAxis("Horizontal");
        Vector3 oldPos = rb.position;
        Vector3 moveAhead = speed * Time.deltaTime * transform.forward;
        Vector3 horizontalMove = 2 * inputHorizontal * horizontalSpeed * Time.deltaTime * transform.right;
        Vector3 newPos = rb.position + moveAhead + horizontalMove;
        if (newPos.x <= -4.5 || newPos.x >= 4.5)
        {
            newPos.x = oldPos.x;
        }
        rb.MovePosition(newPos);
    }

    public void Dead()
    {
        alive = false;
    }

    public void Alive()
    {
        alive = true;
    }
}
