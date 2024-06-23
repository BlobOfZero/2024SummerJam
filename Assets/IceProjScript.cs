using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceProjScript : MonoBehaviour
{
    public float speed;

    private GameObject player;
    private Rigidbody2D rb;
    private float timer;
    [SerializeField] private int damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Damageable damageable = other.GetComponent<Damageable>();

        if (damageable != null && other.gameObject.CompareTag("Player"))
        {
            damageable.Hit(damage);
            Destroy(gameObject);
        }
    }
}
