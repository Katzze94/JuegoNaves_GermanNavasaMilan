using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
      public static EnemyPool Instance;

    public GameObject enemyPrefab; // Prefab del enemigo
    public int poolSize = 10; // Tamaño del pool
    private List<GameObject> enemyPool; // Lista de objetos en el pool

    void Awake()
    {
        Instance = this; // Asignar la instancia
        enemyPool = new List<GameObject>();

        // Crear pool para enemigos
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }

    public GameObject GetPooledEnemy()
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                return enemy; // Retornar el objeto inactivo
            }
        }
        return null; // Retornar null si no hay objetos disponibles
    }
}
