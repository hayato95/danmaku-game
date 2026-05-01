using UnityEngine;
using System.Collections;

public class  WaveManager : MonoBehaviour
{
    public static WaveManager Instance { get; private set;}
    private int remainingEnemies = 0;

    private void Awake()
    {
        Instance = this;
        
    }


    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int enemiesPerWave = 5;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float waveCooldown = 3f;
    [SerializeField] private int totalWaves = 5;

    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(RunWaves());
    }

    private IEnumerator RunWaves()
    {
        while(currentWave < totalWaves)
        {
            currentWave++;
            Debug.Log($"Wave {currentWave} starting!");

            yield return StartCoroutine(SpawnWaves());
            yield return new WaitForSeconds(waveCooldown); // 次のWaveまでのクールダウン

        }
    }

    private IEnumerator SpawnWaves()
    {
        for(int i=0; i< enemiesPerWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval); //一体ずつ間隔を開けてスポーンさせる
        }

        yield return new WaitUntil(() => remainingEnemies <= 0); //全ての敵が倒されるまで待つ  

    }

    private void SpawnEnemy()
    {

        float randomX = Random.Range(-2.5f, 2.5f);
        Vector3 spawnPos = new Vector3(randomX, 6f, 0);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        remainingEnemies++;
    }

    public void OnEnemyDefeated()
    {
        remainingEnemies--;
    }
}