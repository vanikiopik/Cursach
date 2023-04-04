using System;
using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private Animator animator;


    public ParticleSystem m_ParticleSystem;
    public AudioSource m_AudioSource;
    public AudioSource m_AudioSourceReload;
    public Light m_Light;

    private bool canReload = true;
    private bool canShoot = true;
    private float delayBetweenShots = .2f;
    private float reloadCooldown = 3.1f;
    public float bulletSpeed = 100f;
    private int _damage = 20;

    [SerializeField] private int _availableBullets = 30;
    [SerializeField] private int _bulletsInBag = 90;
    private int _maxBullets;

    [SerializeField] private int poolCount = 3;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private Bullet bullerPrefab;

    private PoolMono<Bullet> pool;

    public event Action<int, int> BulletChange;


    private void Start()
    {
        this.pool = new PoolMono<Bullet>(bullerPrefab, poolCount);
        this.pool.autoExpand = autoExpand;

        animator = gameObject.GetComponent<Animator>();
        _maxBullets = _availableBullets;
    }

    private void Update()
    {
        if (_bulletsInBag == 0 && _availableBullets == 0)
        {
            return;
        }
        if (_availableBullets == 0)
        {
            Reload();
        }
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
        if (canReload)
        {
            m_AudioSourceReload.Play();
            animator.SetTrigger("Reload");
            StartCoroutine(ReloadCoroutine());
        }
    }

    void BulletShoot()
    {
        RaycastHit hit;
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out hit))
        {
            Zombie zombie = hit.collider.GetComponent<Zombie>();
            if (zombie != null) zombie.TakeDamage(_damage);
        }

        var bullet = this.pool.GetFreeElement();
        bullet.transform.position = bulletSpawn.position;
        bullet.transform.rotation = bulletSpawn.rotation;
        bullet.GetComponent<Rigidbody>().velocity = ray.direction * bulletSpeed;
    }


    IEnumerator ShootCoroutine()
    {
        canShoot = false;
        canShoot = false;
        m_Light.enabled = true;
        yield return new WaitForSeconds(delayBetweenShots);
        _availableBullets--;
        OnBulletChange();
        m_Light.enabled = false;
        canShoot = true;
        canReload = true;
    }

    IEnumerator ReloadCoroutine()
    {
        canShoot = false;
        canReload = false;
        yield return new WaitForSeconds(reloadCooldown);

        var bulletsToLoad = Mathf.Min(_maxBullets - _availableBullets, _bulletsInBag);
        _availableBullets += bulletsToLoad;
        _bulletsInBag -= bulletsToLoad;
        OnBulletChange();
        canShoot = true;
        canReload = true;
    }

    private void OnBulletChange()
    {
        BulletChange?.Invoke(_availableBullets, _bulletsInBag);
    }
}
