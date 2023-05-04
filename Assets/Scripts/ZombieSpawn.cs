using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public List<GameObject> zombies;

    private void Start()
    {
        foreach (var zombie in zombies)
            zombie.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var zombie in zombies)
                zombie.SetActive(true);
        }
    }
}
