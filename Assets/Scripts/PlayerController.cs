using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 0.1f;
    public float jumpDuration = 0.5f;
    public Rigidbody rb;
    float inputHorizontal;
    private Animator anim;
    private bool isJumping = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");

        if (!isJumping)
        {
            Vector3 moveAhead = speed * Time.deltaTime * transform.forward;
            Vector3 horizontalMove = 2 * inputHorizontal * speed * Time.deltaTime * transform.right;
            rb.MovePosition(rb.position + moveAhead + horizontalMove);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            StartCoroutine(JumpRoutine());
        }
    }

    private IEnumerator JumpRoutine()
    {
        isJumping = true;
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        yield return new WaitForSeconds(jumpDuration);
        isJumping = false;
    }
}
