using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Kill");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Kill");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
