using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPool : MonoBehaviour
{
      public static PlayerBulletPool Instance;

    public GameObject bulletPrefab; 
    public int poolSize = 10; 
    private List<GameObject> bulletPool; 
    void Awake()
    {
        Instance = this; 
        bulletPool = new List<GameObject>();

       
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
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
