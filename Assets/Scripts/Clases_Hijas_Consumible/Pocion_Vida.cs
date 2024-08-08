using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocion_Vida : Consumible
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
    protected override void RealizarAccion()
    {
        // Obtenemos la instancia de CanvasManager para manejar la recuperación de vida.
        CanvasManager canvasManager = CanvasManager.Instance;

        if (canvasManager != null)
        {
            // Intentamos recuperar la vida y verificamos si se pudo realizar.
            bool vidaRecuperada = canvasManager.RecuperarHP();

            if (vidaRecuperada)
            {
                // Si la vida fue recuperada, destruimos el objeto.
                Destruir();
            }
        }
    }
}