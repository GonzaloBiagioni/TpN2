using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocion_Vida : Consumible
{
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
    protected override void RealizarAccion()
    {
        // acá hay que poner la lógica para que aumente la vida del personaje
    }
}
