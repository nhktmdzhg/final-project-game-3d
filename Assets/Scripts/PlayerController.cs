using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    private readonly float horizontalSpeed = 5;
    [SerializeField] float jumpForce = 310f;
    [SerializeField] float jumpCooldown = 0.2f;
    private float lastJumpTime = 0f;
    public Rigidbody rb;
    float inputHorizontal;
    public bool alive = true;
    private Animator anim;
    public float speedIncreasePerPoint = 0.1f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Canvas cooldownCanvas;
    TextMeshProUGUI cooldownText;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
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

    private bool IsGrounded()
    {
        float height = GetComponentInChildren<CapsuleCollider>().bounds.size.y;
        return Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.001f, groundMask);
    }

    private bool CanJump()
    {
        return IsGrounded() && (Time.time - lastJumpTime > jumpCooldown);
    }

    private void Jump()
    {
        lastJumpTime = Time.time;
        rb.AddForce(Vector3.up * jumpForce);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CanJump())
        {
            Jump();
        }
        if (!CanJump())
        {
            cooldownCanvas.gameObject.SetActive(true);
            cooldownText = cooldownCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            cooldownText.text = "COOLDOWN: " + (jumpCooldown - (Time.time - lastJumpTime)).ToString("F1") + "s";
        }
        else { cooldownCanvas.gameObject.SetActive(false); }
        speed += 0.001f;
    }
}
