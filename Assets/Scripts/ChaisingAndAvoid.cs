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
        // проверяем, находится ли объект достаточно близко к цели 
        if (Vector3.Distance(transform.position, target.position) > stoppingDistance)
        {
            // объект находится на достаточном расстоянии от цели, двигаемся к цели с учетом обхода препятствий
            if (!isObstacleAvoidance)
            {
                // если обход препятствия не происходит, двигаемся прямо к цели
                currentDestination = target.position;
            }
            else
            {
                // если происходит обход препятствия, двигаемся в заданном направлении
                currentDestination = transform.position + obstacleAvoidanceDirection * obstacleDistance;
            }

            // используем алгоритм A* для нахождения оптимального пути
           // List<Vector3> path = AStar.FindPath(transform.position, currentDestination, obstacleLayer);

            // двигаем объект по найденному пути с заданной скоростью
           /* if (path != null && path.Count > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, path[0], speed * Time.deltaTime);
            }*/
        }
        else
        {
            // объект находится достаточно близко к цели, останавливаем его
            transform.position = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // обнаружено препятствие, начинаем обходить его
        if (obstacleLayer == (obstacleLayer | (1 << other.gameObject.layer)))
        {
            isObstacleAvoidance = true;

            // находим направление, в котором нужно обойти препятствие
            Vector3 directionToObstacle = other.transform.position - transform.position;
            Vector3 avoidanceDirection = Vector3.Cross(Vector3.up, directionToObstacle);
            obstacleAvoidanceDirection = avoidanceDirection.normalized;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // препятствие успешно обойдено, продолжаем движение к цели
        if (obstacleLayer == (obstacleLayer | (1 << other.gameObject.layer)))
        {
            isObstacleAvoidance = false;
        }
    }
}
