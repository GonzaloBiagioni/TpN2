using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : Consumible
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
    protected override void RealizarAccion()
    {
        //ac� habr�a que sobreescribir y poner la l�gica para llamar al metodo que modifica el contador de shurikens 
    }
}
