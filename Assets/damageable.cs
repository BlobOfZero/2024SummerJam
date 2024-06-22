using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageable : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;

    public int maxHealth
    { get { return _maxHealth; } set { _maxHealth = value; } }

    [SerializeField] private bool _isAlive = true;
    public bool isAlive
    { get { return _isAlive; } set { _isAlive = value; } }

    [SerializeField] private int _health = 100;
    public int health { get { return _health; }
    set
        {
            _health = value;

            if(_health <= 0)
            {
                isAlive = false;
            }
        }
    }

    public void Hit(int damage)
    {

    }
}
