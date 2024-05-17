using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moneda : Consumible
{
    public int value;
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other); 
    }
    protected override void RealizarAccion()
    {
        MonedaContador.Instance.IncreaseCoin(value);
    }
}
