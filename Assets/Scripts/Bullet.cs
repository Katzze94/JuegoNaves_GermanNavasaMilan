using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y > Camera.main.orthographicSize)
        {
            gameObject.SetActive(false); // Desactivar si sale de la cámara
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            gameObject.SetActive(false); // Desactivar el proyectil al impactar
            collision.gameObject.SetActive(false); // Desactivar el enemigo
        }
    }
}
