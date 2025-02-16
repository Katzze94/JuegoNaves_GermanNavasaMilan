using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
      public static EnemyPool Instance;

    public GameObject enemyPrefab; 
    public int poolSize = 10; 
    private List<GameObject> enemyPool; 

    void Awake()
    {
        Instance = this; 
        enemyPool = new List<GameObject>();

        
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
                return enemy; 
            }
        }
        return null; 
    }
}
