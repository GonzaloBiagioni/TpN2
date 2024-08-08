using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilMarronEnemigos : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de la bala, ajustable desde el inspector
    public float tiempoVida = 2f; // Tiempo después del cual la bala se destruye

    private void Start()
    {
        // Destruye la bala después de `tiempoVida` segundos
        Destroy(gameObject, tiempoVida);
    }

    private void Update()
    {
        // Mueve la bala horizontalmente
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);
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