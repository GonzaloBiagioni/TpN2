using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocion_Velocidad : Consumible
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
    protected override void RealizarAccion()
    {
        //ac� hay que poner la l�gica para que aumente la velocidad del personaje
    }
}
