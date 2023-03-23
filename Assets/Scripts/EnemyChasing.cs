using UnityEngine;
using UnityEngine.AI;

public class EnemyChasing : MonoBehaviour
{

    public Transform player;
    [SerializeField] private float _visibleDistance = 5f;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < _visibleDistance)
        {
        // Устанавливаем пункт назначения на текущее положение игрока
        navMeshAgent.SetDestination(player.position);
        }
    }
}
