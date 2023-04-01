using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject enemyPrefab; 
    public float interval = 5f; 
    public Collider platformCollider; 
    private float timer; 

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            CreateEnemy();
            timer = 0f;
        }
    }

    void CreateEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, GetRandomPosition(), Quaternion.identity);
    }

    Vector3 GetRandomPosition()
    {
        Vector3 center = platformCollider.bounds.center;
        Vector3 size = platformCollider.bounds.size;
        float x = Random.Range(center.x - size.x / 2f, center.x + size.x / 2f);
        float z = Random.Range(center.z - size.z / 2f, center.z + size.z / 2f);
        Vector3 position = new Vector3(x, center.y, z);
        return position;
    }
}