using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Camera playerCamera; // —сылка на камеру игрока
    public GameObject bulletPrefab; // —сылка на префаб пули
    public Transform bulletSpawn; // —сылка на точку, где пул€ будет по€вл€тьс€
    public float bulletSpeed = 100f; // —корость пули


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

        // 1st person view
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        // Create the bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        // Make bullet move
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
