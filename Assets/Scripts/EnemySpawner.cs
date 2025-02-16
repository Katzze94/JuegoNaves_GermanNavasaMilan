using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{public float spawnInterval = 2f; // Intervalo de tiempo entre spawns
    public float spawnRangeX = 8f; // Rango en el eje X para el spawn
    public float spawnY = 6f; // Altura en el eje Y donde aparecerán los enemigos

    public GameObject enemyPrefab;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval); // Llamar a SpawnEnemy repetidamente
    }

    void SpawnEnemy()
    {
        // Generar una posición aleatoria en el rango definido
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector2 spawnPosition = new Vector2(randomX, spawnY); // Posición de spawn

        // Obtener un enemigo del pool
        GameObject enemy = EnemyPool.Instance.GetPooledEnemy();
        if (enemy != null)
        {
            enemy.transform.position = spawnPosition; // Establecer la posición del enemigo
            enemy.SetActive(true); // Activar el enemigo
        }
    }
}
