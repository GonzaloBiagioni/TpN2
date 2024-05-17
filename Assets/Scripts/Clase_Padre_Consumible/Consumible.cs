using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumible : MonoBehaviour
{
    // M�todo para detectar la colisi�n con el jugador
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Llamar a un m�todo virtual que puede ser sobrescrito por las clases hijas
            RealizarAccion();
            Destruir();
        }
    }

    // M�todo que ser� sobrescrito por las clases hijas para definir su acci�n espec�fica
    protected abstract void RealizarAccion();
    protected virtual void Destruir()
    {
        Destroy(gameObject);
    }  

}

