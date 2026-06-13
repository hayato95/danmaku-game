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


    [SerializeField] private float waveCooldown = 3f;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private WaveData[] waves; // ScriptableObjectで定義されたWaveのデータ

    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(RunWaves());
    }

    private IEnumerator RunWaves()
    {
        while(currentWave < waves.Length)
        {
            Debug.Log($"Wave {currentWave} starting!");
            yield return StartCoroutine(SpawnWaves());
            currentWave++;
            yield return new WaitForSeconds(waveCooldown); // 次のWaveまでのクールダウン

        }

        SpawnBoss(); // 全てのWaveが終了したらボスをスポーン
    }

    private IEnumerator SpawnWaves()
    {
        for(int i=0; i< waves[currentWave].EnemyCount ; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(waves[currentWave].SpawnInterval); //一体ずつ間隔を開けてスポーンさせる
        }

        yield return new WaitUntil(() => remainingEnemies <= 0); //全ての敵が倒されるまで待つ  

    }

    private void SpawnEnemy()
    {

        float randomX = Random.Range(-2.5f, 2.5f);
        Vector3 spawnPos = new Vector3(randomX, 6f, 0);
        Instantiate(waves[currentWave].EnemyPrefab, spawnPos, Quaternion.identity);
        remainingEnemies++;
    }

    public void OnEnemyDefeated()
    {
        remainingEnemies--;
    }


    private void SpawnBoss()
    {
        Instantiate(bossPrefab, new Vector3(0, 6f, 0), Quaternion.identity);
    }
}