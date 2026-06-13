using UnityEngine;

[System.Serializable]
public class WaveData
{
    [SerializeField] private GameObject enemyPrefab;
    public GameObject EnemyPrefab => enemyPrefab; // 読み取り専用のプロパティ

    [SerializeField] private int enemyCount;
    public int EnemyCount => enemyCount;

    [SerializeField] private float spawnInterval;
    public float SpawnInterval => spawnInterval;

}
