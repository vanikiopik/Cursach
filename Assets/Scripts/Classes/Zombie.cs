using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : Person
{
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackDamage = 20;
    public Slider healthBar;
    private EnemyAnimation _enemyAnimation;
    private bool _canAttack = true;
    [SerializeField] private float _attackCooldown = 2.0f;

    public event Action<float> HealthChanged;


    private void Start()
    {
 
        _enemyAnimation = GetComponent<EnemyAnimation>();
    }

    private void Update()
    {
        healthBar.transform.forward = -Camera.main.transform.forward;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        UpdateHealthBar(_health);
        if (_health <= 0.1)
        {
            Die();
        }
        else HealthChanged?.Invoke(_health);
    }

    public void Attack(Collision collision)
    {
    }

    void UpdateHealthBar(float currentHealth)
    {
        healthBar.value = currentHealth;
    }

    private IEnumerator attackCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_attackCooldown);
        _canAttack = true;
    }
}
