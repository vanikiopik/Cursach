using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifetime = 3f;

    private void OnEnable()
    {
        this.StartCoroutine(LifeRoutine());
    }

    private void OnDisable()
    {
        this.StopCoroutine(LifeRoutine());   
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSeconds(_lifetime);

        this.Deactivate();
    }

    private void OnCollisionEnter(Collision collision)
    {        
        Zombie enemy = collision.collider.GetComponent<Zombie>();
        if (enemy != null)
        {
            Deactivate();
        }
    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
