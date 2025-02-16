using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{ public float speed = 5f; 

    void Update()
    {
        
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        
        if (transform.position.y < -Camera.main.orthographicSize)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Die();
            }
            gameObject.SetActive(false); 
        }
    }
}
