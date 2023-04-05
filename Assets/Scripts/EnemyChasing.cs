using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChasing : MonoBehaviour
{
    [SerializeField] private float _visibleDistance = 5f;
    [SerializeField] private float _attackDistance = 3f;

    private NavMeshAgent navMeshAgent;
    private EnemyAnimation _enemyAnimation;
    
    public WeaponController _weaponController;

    public bool isAttacking = false;
    public bool isChasingForSound = false;

    private void Awake()
    {
        _weaponController.OnShootAction += GetEnemyShootSound;
    }

    private void OnDestroy()
    {
        _weaponController.OnShootAction -= GetEnemyShootSound;
        navMeshAgent = null;
    }

    private void Start()
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        
        if (Mathf.Approximately(navMeshAgent.velocity.sqrMagnitude , 0))
        {
            _enemyAnimation.SetIdleAnimation();
        }
        else
        {
            _enemyAnimation.SetWalkAnimation();
        }
    }

    public void WalkToTarget(Vector3 position)
    {
        isChasingForSound = false;
        navMeshAgent.SetDestination(position);
    }

    public void Attack()
    {
        _enemyAnimation.SetAttackAnimation();
    }

    public void LostVision()
    {
        if (!isChasingForSound)
        {
            navMeshAgent.ResetPath();
        }
    }

    private void GetEnemyShootSound(Vector3 position)
    {
        isChasingForSound=true;
        _enemyAnimation.SetWalkAnimation();
        navMeshAgent.SetDestination(position); 
    }
}
