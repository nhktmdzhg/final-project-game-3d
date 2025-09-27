using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    [SerializeField] Rigidbody rb;
    float inputHorizontal;
    private bool alive = true;
    private Animator anim;
    public float speedIncreasePerPoint = 0.02f;

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
        Vector3 moveAhead = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * inputHorizontal * speed * Time.fixedDeltaTime * 2;
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
