using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int minCount = 5;
    private int maxCount = 12;

    private int minRate = 3;
    private int maxRate = 8;

    public TextMeshProUGUI waveCountdownText;
    public TextMeshProUGUI WaveNumberText;
    public TextMeshProUGUI LevelNumberText;

    private int waveIndex = 0;

    public GameManager gameManager;

    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        EnemiesAlive = 0;
        PlayerStats.Rounds = 0;
        WaveNumberText.text = "Wave:1";
        LevelNumberText.text = "Level: " + SceneFader.LevelToInt();
    }
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }
    IEnumerator SpawnWave()
    {

        Debug.Log("SpawnWave started!");
        PlayerStats.Rounds++;

        waveIndex++;
        if (waveIndex < 3 + (SceneFader.LevelToInt()-1)*2)
        {
            WaveNumberText.text = "Wave: " + waveIndex;
            LevelNumberText.text = "Level: " + SceneFader.LevelToInt();

            // Randomly select count and rate values
            int randomCount = Random.Range(minCount, maxCount + 1);
            float randomRate = Random.Range(minRate, maxRate);

            EnemiesAlive = randomCount;
            for (int i = 0; i < randomCount; i++)
            {
                // Randomly select an enemy prefab from the wave's array
                int randomEnemyPrefabIndex = Random.Range(0, waves.Length);
                GameObject randomEnemyPrefab = waves[randomEnemyPrefabIndex].enemy;

                // Instantiate an enemy of the selected prefab
                GameObject spawnedEnemy = Instantiate(randomEnemyPrefab, spawnPoint.position, spawnPoint.rotation);


                yield return new WaitForSeconds(1f / randomRate);
            }

        }
        else
        {
            // No more waves, you've won the level or completed all waves
            gameManager.WinLevel();
            this.enabled = false;
        }
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
