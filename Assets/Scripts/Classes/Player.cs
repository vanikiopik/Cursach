using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Person
{

    public event Action<float> HealthChanged;

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0.1)
        {
            HealthChanged?.Invoke(0);
            Die();
        }
        else
            HealthChanged?.Invoke(_health); 
    }
}
