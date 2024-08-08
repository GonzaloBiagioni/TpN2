using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocion_Velocidad : Consumible
{
    public float incrementoDeVelocidad = 2f; // Incremento de velocidad
    public float duracionEfecto = 2f; // Duración del efecto en segundos
    protected override void RealizarAccion()
    {
        Player jugador = FindObjectOfType<Player>();
        if (jugador != null)
        {
            // Incrementar la velocidad del jugador
            jugador.IncrementarVelocidad(incrementoDeVelocidad, duracionEfecto);
            Destruir();
        }
        else
        {
            Destruir();
        }
    }
}
