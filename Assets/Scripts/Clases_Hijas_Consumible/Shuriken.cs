using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : Consumible
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
    protected override void RealizarAccion()
    {
        //acá habría que sobreescribir y poner la lógica para llamar al metodo que modifica el contador de shurikens 
    }
}
