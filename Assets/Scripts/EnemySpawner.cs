using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{public float spawnInterval = 2f; 
    public float spawnRangeX = 8f; 
    public float spawnY = 6f; 
    public GameObject enemyPrefab;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval); 
    }

    void SpawnEnemy()
    {
      
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector2 spawnPosition = new Vector2(randomX, spawnY);

       
        GameObject enemy = EnemyPool.Instance.GetPooledEnemy();
        if (enemy != null)
        {
            enemy.transform.position = spawnPosition; 
            enemy.SetActive(true); 
        }
    }
}
