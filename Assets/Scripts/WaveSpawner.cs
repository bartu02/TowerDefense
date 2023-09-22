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

    public TextMeshProUGUI waveCountdownText;

    private int waveIndex = 0;

    public GameManager gameManager;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(EnemiesAlive >0)
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
        PlayerStats.Rounds++;

        waveIndex++;
        if (waveIndex < waves.Length)
        {
            // Access the wave and spawn enemies if it's within the array bounds
            Wave wave = waves[waveIndex];

            EnemiesAlive = wave.count;
            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy(wave.enemy);
                yield return new WaitForSeconds(1f / wave.rate);
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
