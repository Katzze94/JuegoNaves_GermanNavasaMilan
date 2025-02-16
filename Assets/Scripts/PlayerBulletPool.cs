using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPool : MonoBehaviour
{
      public static PlayerBulletPool Instance;

    public GameObject bulletPrefab; // Prefab del proyectil
    public int poolSize = 10; // Tamaño del pool
    private List<GameObject> bulletPool; // Lista de objetos en el pool

    void Awake()
    {
        Instance = this; // Asignar la instancia
        bulletPool = new List<GameObject>();

        // Crear pool para proyectiles del jugador
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
                return bullet; // Retornar el objeto inactivo
            }
        }
        return null; // Retornar null si no hay objetos disponibles
    }
}
