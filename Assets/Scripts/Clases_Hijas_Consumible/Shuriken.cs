using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : Consumible

{
    public float velocidad = 5f;
    private Vector2 direccionMovimiento;
    public float tiempoDeVida = 2f;

    private void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }

    public void SetDireccion(Vector2 direccion)
    {
        direccionMovimiento = direccion.normalized;
    }

    private void Update()
    {
        transform.Translate(direccionMovimiento * velocidad * Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        // Ignorar colisiones con el Player
        if (other.CompareTag("Player"))
        {
            return;
        }

        // Colisión con el enemigo
        if (other.CompareTag("Enemy"))
        {
            // Verifica si el objeto con el que colisiona es un enemigo (o un objeto que hereda de Enemigo)
            Enemigo enemigo = other.GetComponent<Enemigo>();
            if (enemigo != null)
            {
                Debug.Log("enemigo");
                enemigo.RecibirDaño(); // Llama al método RecibirDaño del enemigo o de sus hijos
            }

            
        }
        // Destruir el shuriken tras impactar con el enemigo
        Destruir();
    }
    protected override void RealizarAccion()
    {
    }
}