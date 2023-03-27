using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Person
{
    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0.1)
        {
            Die();
        }
    }

}
