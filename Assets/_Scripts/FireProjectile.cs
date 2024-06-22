using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private Vector2 projectileSpeed = new Vector2(3f, 0);

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.velocity = new Vector2(projectileSpeed.x * transform.localScale.x, projectileSpeed.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable != null)
        {
            damageable.Hit(damage);
            Debug.Log("fire attack damaged " + damage);
            Destroy(gameObject);
        }
    }
}
