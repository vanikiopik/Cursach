using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage = 20;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            Zombie enemy = collision.collider.GetComponent<Zombie>();
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
