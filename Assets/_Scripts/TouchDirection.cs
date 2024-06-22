using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDirection : MonoBehaviour
{
    CircleCollider2D touchingCol;

    public ContactFilter2D castFilter;
    public float groundDistance = 0.05f;
    public float wallDistance = 0.2f;
    public float ceilingDistance = 0.05f;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];

    [SerializeField] private bool _isGrounded;

    public bool isGrounded { get {
            return _isGrounded;
        } private set {
            _isGrounded = value;
        } }

    [SerializeField] private bool _isOnWall;

    public bool isOnWall
    {
        get
        {
            return _isOnWall;
        }
        private set
        {
            _isOnWall = value;
        }
    }

    [SerializeField] private bool _isOnCeiling;

    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    public bool isOnCeiling
    {
        get
        {
            return _isOnCeiling;
        }
        private set
        {
            _isOnCeiling = value;
        }
    }

    private void Awake()
    {
        touchingCol = GetComponent<CircleCollider2D>();
    }

    private void FixedUpdate()
    {
        // if the down cast returns greater then 1 player is grounded
        isGrounded = touchingCol.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
        isOnWall = touchingCol.Cast(wallCheckDirection, castFilter, wallHits, wallDistance) > 0;
        isOnCeiling = touchingCol.Cast(Vector2.up, castFilter, ceilingHits, ceilingDistance) > 0;
    }
}
