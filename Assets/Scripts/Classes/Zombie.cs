using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : Person
{
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackDamage = 20;
    public Slider healthBar;

    public void TakeDamage(float damage)
    {
        _health -= damage;
        UpdateHealthBar(_health);   
        if(_health <= 0.1)
        {
            Die();
        }
    }

    void UpdateHealthBar(float currentHealth)
    {
        healthBar.value = currentHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(_attackDamage);
        }
    }
}

 