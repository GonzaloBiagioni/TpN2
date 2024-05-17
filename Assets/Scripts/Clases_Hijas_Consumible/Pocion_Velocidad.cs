using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocion_Velocidad : Consumible
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
    protected override void RealizarAccion()
    {
        //acá hay que poner la lógica para que aumente la velocidad del personaje
    }
}
