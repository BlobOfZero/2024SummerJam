using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int health;

    private void Start()
    {
        health = maxHealth;
    }

    public void Hit(int damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
        else Destroy(gameObject);
    }
}
