using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{     public static ObjectPool Instance;

    public GameObject bulletPrefab; // Prefab del proyectil del jugador
    public GameObject enemyPrefab; // Prefab del enemigo
    public GameObject enemyBulletPrefab;

    public int poolSize = 10; // Tamaño del pool
    private List<GameObject> bulletPool; // Lista de objetos en el pool de balas
    private List<GameObject> enemyPool; // Lista de objetos en el pool de enemigos

    private List<GameObject> enemyBulletPool;

    void Awake()
    {
        Instance = this; // Asignar la instancia
        bulletPool = new List<GameObject>();
        enemyPool = new List<GameObject>();
        enemyBulletPool =  new List<GameObject>();

        // Crear pool para proyectiles del jugador
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }

        // Crear pool para enemigos
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }

          for (int i = 0; i < poolSize; i++)
        {
            GameObject enemyBullet = Instantiate(enemyBulletPrefab);
            enemyBullet.SetActive(false);
            enemyBulletPool.Add(enemyBullet);
        }


    }

    public GameObject GetPooledBullet()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet; // Retornar el objeto inactivo
            }
        }
        return null; // Retornar null si no hay objetos disponibles
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

    public GameObject GetPooledEnemyBullet()
{
    foreach (GameObject bullet in enemyBulletPool)
    {
        if (!bullet.activeInHierarchy)
        {
            return bullet; // Retornar el objeto inactivo
        }
    }
    return null; // Retornar null si no hay objetos disponibles
}
}
