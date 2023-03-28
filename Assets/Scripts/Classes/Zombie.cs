using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : Person
{
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackDamage = 20;
    public Slider healthBar;
    private EnemyAnimation _enemyAnimation;

    private void Start()
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        UpdateHealthBar(_health);   
        if(_health <= 0.1)
        {
            Die();
        }
    }

    public void Attack(Collision collision)
    {
        //_enemyAnimation.SetAttackAnimation();
        collision.gameObject.GetComponent<Player>().TakeDamage(_attackDamage);
    }

    void UpdateHealthBar(float currentHealth)
    {
        healthBar.value = currentHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack(collision);
        }
    }
}

 