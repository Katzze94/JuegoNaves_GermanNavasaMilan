using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   public float speed = 2f;
    public GameObject bulletPrefab; // Prefab del proyectil del enemigo
    public Transform EnemyBulletSpawnPoint; // Punto de donde se generarán los proyectiles
    public float fireRate = 1f; // Frecuencia de disparo
    private float nextFireTime = 0f; // Tiempo para el próximo disparo

    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y < -Camera.main.orthographicSize)
        {
            gameObject.SetActive(false); // Desactivar si sale de la cámara
        }
    }

    void Shoot()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate; // Establecer el tiempo para el próximo disparo
            GameObject bullet = EnemyBulletPool.Instance.GetPooledBullet(); // Obtener un proyectil del pool
            if (bullet != null)
            {
                bullet.transform.position = EnemyBulletSpawnPoint.position; // Establecer la posición del proyectil
                bullet.SetActive(true); // Activar el proyectil
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el objeto que colisiona es una bala del jugador
        if (collision.CompareTag("Bullet"))
        {
            gameObject.SetActive(false); // Desactivar el enemigo al ser impactado
            collision.gameObject.SetActive(false); // Desactivar el proyectil del jugador
        }
    }
}
