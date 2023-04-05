using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] private float _triggerRadius = 5f;
    [SerializeField] private float _attackRadius = 2f;

    private EnemyChasing _enemyChasing;

    private void Awake()
    {
        _enemyChasing = GetComponentInParent<EnemyChasing>();
    }

    private void Update()
    {
        if (_enemyChasing.isAttacking)
            return;

        var coliders = Physics.OverlapSphere(transform.position, _triggerRadius, LayerMask.GetMask("Player"));
        var colidersToAttack = Physics.OverlapSphere(transform.position, _attackRadius, LayerMask.GetMask("Player"));


        if (colidersToAttack.Length > 0)
            _enemyChasing.Attack();

        if (coliders.Length > 0)
            _enemyChasing.WalkToTarget();
        else
            _enemyChasing.LostVision();
    }
}
