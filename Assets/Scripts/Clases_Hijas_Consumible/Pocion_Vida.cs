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
        // ac� hay que poner la l�gica para que aumente la vida del personaje
    }
}
