using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocion_Vida : Consumible
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
    protected override void RealizarAccion()
    {
        // acá hay que poner la lógica para que aumente la vida del personaje
    }
}
