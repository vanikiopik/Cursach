using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChasing : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float _visibleDistance = 5f;
    [SerializeField] private float _attackDistance = 3f;

    private NavMeshAgent navMeshAgent;
    private EnemyAnimation _enemyAnimation;
    //Distance between player and enemy
    private float _distance;

    private void Start()
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _distance = Vector3.Distance(transform.position, target.transform.position);

        if (_distance < _attackDistance)
        {
            Debug.Log("Attack");
            _enemyAnimation.SetAttackAnimation();
        }
        else if(_distance < _visibleDistance && _distance > _attackDistance)
        {
            Debug.Log("Move");
            _enemyAnimation.SetWalkAnimation();
            navMeshAgent.SetDestination(target.position);
        }
        else
        {
            Debug.Log("Reset");
            navMeshAgent.ResetPath();
        }
    }
}
