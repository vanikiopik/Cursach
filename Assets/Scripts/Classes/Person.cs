using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField]protected float _health = 100;

    public void Die()
    {
        Destroy(gameObject);
    }
}
