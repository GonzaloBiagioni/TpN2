using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumible : MonoBehaviour
{
    // Método para detectar la colisión con el jugador
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Llamar a un método virtual que puede ser sobrescrito por las clases hijas
            RealizarAccion();
            Destruir();
        }
    }

    // Método que será sobrescrito por las clases hijas para definir su acción específica
    protected abstract void RealizarAccion();
    protected virtual void Destruir()
    {
        Destroy(gameObject);
    }  

}

