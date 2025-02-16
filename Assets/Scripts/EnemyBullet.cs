using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{ public float speed = 5f; // Velocidad del proyectil

    void Update()
    {
        // Mover el proyectil hacia abajo
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // Desactivar el proyectil si sale de la cámara
        if (transform.position.y < -Camera.main.orthographicSize)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Aquí puedes agregar lógica para dañar al jugador
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Die(); // Llamar al método de muerte del jugador
            }
            gameObject.SetActive(false); // Desactivar el proyectil al impactar
        }
    }
}
