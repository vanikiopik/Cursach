using UnityEngine;
using UnityEngine.AI;

public class EnemyChasing : MonoBehaviour
{

    public Transform target;
    [SerializeField] private float _visibleDistance = 5f;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, target.transform.position) < _visibleDistance)
        {
            navMeshAgent.SetDestination(target.position);
        }
        else
        {

        }
    }
}
