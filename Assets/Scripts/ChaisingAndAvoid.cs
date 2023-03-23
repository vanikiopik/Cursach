using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ChaisingAndAvoid : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float stoppingDistance = 1f;
    public float obstacleDistance = 2f;
    public LayerMask obstacleLayer;

    private Vector3 currentDestination;
    private bool isObstacleAvoidance = false;
    private Vector3 obstacleAvoidanceDirection;

    private void Update()
    {
        // ���������, ��������� �� ������ ���������� ������ � ���� 
        if (Vector3.Distance(transform.position, target.position) > stoppingDistance)
        {
            // ������ ��������� �� ����������� ���������� �� ����, ��������� � ���� � ������ ������ �����������
            if (!isObstacleAvoidance)
            {
                // ���� ����� ����������� �� ����������, ��������� ����� � ����
                currentDestination = target.position;
            }
            else
            {
                // ���� ���������� ����� �����������, ��������� � �������� �����������
                currentDestination = transform.position + obstacleAvoidanceDirection * obstacleDistance;
            }

            // ���������� �������� A* ��� ���������� ������������ ����
           // List<Vector3> path = AStar.FindPath(transform.position, currentDestination, obstacleLayer);

            // ������� ������ �� ���������� ���� � �������� ���������
           /* if (path != null && path.Count > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, path[0], speed * Time.deltaTime);
            }*/
        }
        else
        {
            // ������ ��������� ���������� ������ � ����, ������������� ���
            transform.position = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���������� �����������, �������� �������� ���
        if (obstacleLayer == (obstacleLayer | (1 << other.gameObject.layer)))
        {
            isObstacleAvoidance = true;

            // ������� �����������, � ������� ����� ������ �����������
            Vector3 directionToObstacle = other.transform.position - transform.position;
            Vector3 avoidanceDirection = Vector3.Cross(Vector3.up, directionToObstacle);
            obstacleAvoidanceDirection = avoidanceDirection.normalized;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ����������� ������� ��������, ���������� �������� � ����
        if (obstacleLayer == (obstacleLayer | (1 << other.gameObject.layer)))
        {
            isObstacleAvoidance = false;
        }
    }
}
