using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnZPosition = 10f;
    public Vector2 xBounds = new Vector2(-8.5f, 8.5f);

    public int asteroidsPerWave = 5;
    public float spawnWait = 0.5f;
    public float waveWait = 2f; 
    public float startWait = 1f;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    { 
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            // Spawn asteroids for the current wave
            for (int i = 0; i < asteroidsPerWave; i++)
            {
                SpawnAsteroid();
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);
        }
    }

    void SpawnAsteroid()
    {
        float randomX = Random.Range(xBounds.x, xBounds.y);

        Vector3 spawnPosition = new Vector3(randomX, 0, spawnZPosition);

        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
    }
}
