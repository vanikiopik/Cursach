using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    //private Animation animation;

    private Animator animator;

    bool canShoot = true;
    float delayBetweenShots = .2f;
    
    public ParticleSystem m_ParticleSystem;
    public AudioSource m_AudioSource;
    public Light m_Light;

    private void Start()
    {
       // animation = gameObject.GetComponent<Animation>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
        if (Input.GetKey(KeyCode.R))
        {
            Reload();
        }
    }
    
    void Shoot()
    {
        if (canShoot)
        {
            m_ParticleSystem.Play();
            m_AudioSource.Play();
            animator.SetTrigger("Shot");
            StartCoroutine(ShootCoroutine());
        }
    }

    void Reload()
    {
        animator.SetTrigger("Reload");
    }

    IEnumerator ShootCoroutine()
    {
        canShoot = false;
        m_Light.enabled = true;
        yield return new WaitForSeconds(delayBetweenShots);
        m_Light.enabled = false;
        canShoot = true; 
    }
}
