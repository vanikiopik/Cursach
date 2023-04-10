using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : Person
{
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackDamage = 20;
    public Slider healthBar;
    private EnemyAnimation _enemyAnimation;
    private bool _canAttack = true;
    [SerializeField] private float _attackCooldown = 2.0f;
    [SerializeField] private float _deathCooldown = 3.0f;

    public event Action<float> HealthChanged;

    TriggerZone _triggerZone;
    EnemyChasing _enemyChasing;
    Collider _colider;

    NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _triggerZone = GetComponentInChildren<TriggerZone>();
        _enemyChasing = GetComponentInChildren<EnemyChasing>();
        _colider = GetComponent<Collider>();
        _navMeshAgent = GetComponentInChildren<NavMeshAgent>();

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
            _enemyAnimation.SetDieAnimation();
            
            _triggerZone.enabled = false;
            _enemyAnimation.enabled = false;
            _navMeshAgent.enabled = false;
            _enemyChasing.DeleteAgentPath();
            _enemyChasing.enabled = false;
            _colider.enabled = false;

            StartCoroutine(cooldownAfterDeath());
        }
        else HealthChanged?.Invoke(_health);
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

    private IEnumerator cooldownAfterDeath()
    {
        yield return new WaitForSeconds(_deathCooldown);
        Die();
    }
}
