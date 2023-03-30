using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage = 20;

    private void OnCollisionEnter(Collision collision)
    {        
        Zombie enemy = collision.collider.GetComponent<Zombie>();
        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
