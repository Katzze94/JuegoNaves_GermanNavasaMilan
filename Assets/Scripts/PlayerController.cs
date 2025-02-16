using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{  public float moveSpeed = 5f;
    public GameObject bulletPrefab; 
    public Transform bulletSpawnPoint; 

    private float minX = -7.89f; 
    private float maxX = 7.89f;  

     public AudioSource shootSound;

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
         Vector2 newPosition = transform.position + Vector3.right * moveHorizontal * moveSpeed * Time.deltaTime;


        
        
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        transform.position = newPosition; 
    }

   void Shoot()
    {
        shootSound.Play();
        GameObject bullet = PlayerBulletPool.Instance.GetPooledBullet(); 
        if (bullet != null)
        {
            bullet.transform.position = bulletSpawnPoint.position; 
            bullet.SetActive(true); 
        }
    }

     public void Die()
    {
        Debug.Log("El jugador ha muerto!");
        Destroy(gameObject); 
        SceneManager.LoadScene("Game Over");

       
    }
}
