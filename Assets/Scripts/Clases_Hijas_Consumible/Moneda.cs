using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moneda : Consumible
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other); 
    }
    protected override void RealizarAccion()
    {
        //ac� habr�a que sobreescribir y poner la l�gica para llamar al metodo que modifica el contador de monedas 
    }
}
