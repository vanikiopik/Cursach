using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChasing : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float _visibleDistance = 5f;
    [SerializeField] private float _attackDistance = 3f;
    [SerializeField] private float _chaseTime = 2f;

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

    public void WalkToTarget()
    {
        isChasingForSound = false;
        navMeshAgent.SetDestination(target.position);
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

    private void GetEnemyShootSound()
    {
        isChasingForSound=true;
        _enemyAnimation.SetWalkAnimation();
        navMeshAgent.SetDestination(target.position);
       //StartCoroutine(ChaseTimer());   
    }

/*    private IEnumerator ChaseTimer()
    {
        yield return new WaitForSeconds(_chaseTime);
        LostVision();
    }*/
}
