using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieSpawn : MonoBehaviour
{
    public List<GameObject> zombies;

    private void Awake()
    {
        foreach (var zombie in zombies)
        {
            zombie.GetComponent<NavMeshAgent>().speed = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var zombie in zombies)
            {
                zombie.GetComponent<NavMeshAgent>().speed = 3.5f;
            }
        }
    }
}
