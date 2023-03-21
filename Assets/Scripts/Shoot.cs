using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public Camera playerCamera; // Ссылка на камеру игрока
    public GameObject bulletPrefab; // Ссылка на префаб пули
    public Transform bulletSpawn; // Ссылка на точку, где пуля будет появляться
    public float bulletSpeed = 100f; // Скорость пули

    bool canShoot = true;
    float delayBetweenShots = .2f;

    void Update()
    {
        // Стрельба при нажатии на левую кнопку мыши
        if (Input.GetKey(KeyCode.Mouse0))
        {
            BulletShoot();
        }
    }

    void BulletShoot()
    {
        if (canShoot)
        {
        // 1st person view
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        // Create the bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        // Make bullet move
        bullet.GetComponent<Rigidbody>().velocity = ray.direction * bulletSpeed;

        StartCoroutine(ShootCoroutine());
        }
    }

    IEnumerator ShootCoroutine()
    {
        canShoot = false;
        yield return new WaitForSeconds(delayBetweenShots);
        canShoot = true;
    }
}

