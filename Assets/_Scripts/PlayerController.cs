using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    public float movementSpeed = 5f;
    public float jumpImpulse = 10f;
    public float groundDistance = 0.05f;

    Rigidbody2D rb;
    CapsuleCollider2D capsuleCollider;
    Animator animator;
    RaycastHit2D[] groundhits = new RaycastHit2D[5];

    public ContactFilter2D contactFilter;
    public bool isMoving { get; private set; }
    private bool _isGrounded;
    public bool isGrounded
    {
        get
        {
            return _isGrounded;
        }
        private set
        {
            _isGrounded = value;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * movementSpeed, rb.velocity.y);

        isGrounded = capsuleCollider.Cast(Vector2.down, contactFilter, groundhits, groundDistance) > 0;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
       
        moveInput = context.ReadValue<Vector2>();

        isMoving = moveInput != Vector2.zero;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // check for aliive later
        if (context.started && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }
}
