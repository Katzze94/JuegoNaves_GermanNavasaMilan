using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{  public float moveSpeed = 5f;
    public GameObject bulletPrefab; // Prefab del proyectil
    public Transform bulletSpawnPoint; // Punto de donde se generarán los proyectiles

    void Update()
    {
        Move();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveHorizontal * moveSpeed * Time.deltaTime);
    }

   void Shoot()
    {
        // Obtener el objeto del pool
        GameObject bullet = PlayerBulletPool.Instance.GetPooledBullet(); // Cambiado a GetPooledBullet()
        if (bullet != null)
        {
            bullet.transform.position = bulletSpawnPoint.position; // Establecer la posición del proyectil
            bullet.SetActive(true); // Activar el proyectil
        }
    }

     public void Die()
    {
        Debug.Log("El jugador ha muerto!");
        Destroy(gameObject); // Destruir la nave del jugador
        // Aquí podrías agregar una animación de explosión o un efecto visual
        // También podrías reiniciar el juego o llevar al jugador a una pantalla de Game Over
    }
}
