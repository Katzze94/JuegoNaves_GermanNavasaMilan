using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   public float speed = 2f;
    public GameObject bulletPrefab; 
    public Transform EnemyBulletSpawnPoint; 
        public float fireRate = 1f; 
    private float nextFireTime = 0f; 

    public AudioSource enemyShootSound;

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
            gameObject.SetActive(false); 
        }
    }

    void Shoot()
    {
      
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate; 
            GameObject bullet = EnemyBulletPool.Instance.GetPooledBullet(); 
            if (bullet != null)
            {
                bullet.transform.position = EnemyBulletSpawnPoint.position; 
                bullet.SetActive(true);
                 enemyShootSound.Play();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false); 
        }
    }
}
