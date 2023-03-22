using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Camera playerCamera; 
    public GameObject bulletPrefab; 
    public Transform bulletSpawn; 
    public float bulletSpeed = 100f; 


    private Animator animator;

    private bool canShoot = true;
    private float delayBetweenShots = .2f;
    private float reloadCooldown = 3.1f;
    
    public ParticleSystem m_ParticleSystem;
    public AudioSource m_AudioSource;
    public AudioSource m_AudioSourceReload;
    public Light m_Light;

    private void Start()
    {
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
            BulletShoot();
            animator.SetTrigger("Shot");
            StartCoroutine(ShootCoroutine());
        }
    }

    void Reload()
    {
        m_AudioSourceReload.Play();
        animator.SetTrigger("Reload");
        StartCoroutine(ReloadCoroutine());
    }

    void BulletShoot()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = ray.direction * bulletSpeed;
    }

    IEnumerator ShootCoroutine()
    {
        canShoot = false;
        m_Light.enabled = true;
        yield return new WaitForSeconds(delayBetweenShots);
        m_Light.enabled = false;
        canShoot = true; 
    }

    IEnumerator ReloadCoroutine()
    {
        canShoot = false;
        yield return new WaitForSeconds(reloadCooldown);
        canShoot = true;
    }
}
