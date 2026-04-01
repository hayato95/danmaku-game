using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 2f;

    //検証用で一旦2fにしているが、最終的にはゲームのバランスを見て調整する予定
    [SerializeField] private float spawnRangeX = 2f;

    private float spawnTimer = 0f;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);

        Vector2 spawnPosition = new Vector2(randomX, 6f);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

    }
}