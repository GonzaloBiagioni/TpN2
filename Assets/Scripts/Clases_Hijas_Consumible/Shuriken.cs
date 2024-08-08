using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : Consumible
{
    public float velocidad = 5f; // Velocidad del shuriken
    private Vector2 direccionMovimiento;
    public float tiempoDeVida = 2f; // Tiempo de vida del shuriken en segundos

    private void Start()
    {
        // Destruye el shuriken automáticamente después de `tiempoDeVida` segundos
        Destroy(gameObject, tiempoDeVida);
    }

    public void SetDireccion(Vector2 direccion)
    {
        direccionMovimiento = direccion.normalized;
    }

    private void Update()
    {
        // Movemos el shuriken en la dirección establecida
        transform.Translate(direccionMovimiento * velocidad * Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        // Evitar colisiones con el Player
        if (other.CompareTag("Player"))
        {
            return; // No hacer nada si el shuriken toca al jugador
        }

        if (other.CompareTag("Enemy"))
        {
            // Lógica para dañar al enemigo
            Enemyhealth enemyHealth = other.GetComponent<Enemyhealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(1); // Aplica 1 de daño, suficiente para matar a los enemigos normales
            }

            // Destruye el shuriken al impactar con el enemigo
            Destruir();
        }

        base.OnTriggerEnter2D(other);
    }

    protected override void RealizarAccion()
    {
    }
}