using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilJefe : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de la bala, ajustable desde el inspector
    public float tiempoVida = 2f; // Tiempo después del cual la bala se destruye
    private Transform jugadorTransform; // Referencia al transform del jugador

    private void Start()
    {
        // Encuentra el objeto con el tag "Player" y obtiene su transfor
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            jugadorTransform = jugador.transform;
        }

        // Destruye la bala después de `tiempoVida` segundos
        Destroy(gameObject, tiempoVida);
    }

    private void Update()
    {
        if (jugadorTransform != null)
        {
            // Calcula la dirección hacia el jugador
            Vector2 direccion = (jugadorTransform.position - transform.position).normalized;

            // Mueve el proyectil hacia el jugador
            transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto con el que colisiona tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage();
            }
        }

        // Destruye el proyectil independientemente del objeto con el que colisione
        Destroy(gameObject);
    }
}
