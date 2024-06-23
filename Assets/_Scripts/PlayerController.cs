using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    TouchDirection touchingDirections;
    Vector2 moveInput;
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float jumpImpulse = 10f;

    Damageable damageableScript;

    Rigidbody2D rb;
    Animator animator;

    [SerializeField] private bool _isMoving = false;
    public bool isMoving { get { return _isMoving; }
        private set { _isMoving = value;
        } }

    [SerializeField] private bool _isRunning = false;
    public bool isRunning
    {
        get { return _isRunning; }
        private set
        {
            _isRunning = value;
        }
    }

    public float currentMoveSpeed
    {
        get
        {
            if (isMoving && !touchingDirections.isOnWall)
            {
                if (isRunning)
                {
                    return runSpeed;
                }
                else
                {
                    return walkSpeed;
                }
            }
            else
            {
                return 1f;
            }
        }
    }

    public bool _isFacingRight = true;
    public bool isFacingRight { get { return _isFacingRight; } private set { 
            if(_isFacingRight != value)
            {
                transform.Rotate(0, 180, 0);
            }
            _isFacingRight = value; } }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchDirection>();
    }
    private void FixedUpdate()
    {

        rb.velocity = new Vector2(moveInput.x * currentMoveSpeed, rb.velocity.y);
    }

    // left and right movement code
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        isMoving = moveInput != Vector2.zero;

        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !isFacingRight)
        {
            // face right
            isFacingRight = true;
        }
        else if (moveInput.x < 0 && isFacingRight)
        {
            // face left
            isFacingRight = false;
        }
    }

    // optional sprint
    public void OnRun(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            isRunning = true;
        }
        else if (context.canceled)
        {
            isRunning = false;
        }
    }

    // basic jumping code
    public void OnJump(InputAction.CallbackContext context)
    {
        // check for aliive later
        if (context.started && touchingDirections.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }
}
