using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval; 
    public Vector2 spawnRange = new Vector2(-8, 8); 

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 2f);
    }

    void SpawnEnemy()
    {
        float xPosition = Random.Range(spawnRange.x, spawnRange.y);
        Vector3 spawnPosition = new Vector3(xPosition, transform.position.y, 0f);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
