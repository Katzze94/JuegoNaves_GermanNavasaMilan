using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour
{
    public static EnemyBulletPool Instance;

    public GameObject EnemyBulletPrefab; 
    public int poolSize = 10; 
    private List<GameObject> bulletPool; 

    void Awake()
    {
        Instance = this; 
        bulletPool = new List<GameObject>();

       
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(EnemyBulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    public GameObject GetPooledBullet()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet; 
            }
        }
        return null; 
    }
}
