using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_Jefe : Enemigo
{
    private void Start()
    {
        Atacar();
    }
    public override void Atacar()
    {
        base.Atacar(); 
    }

    public override void RecibirDaņo()
    {
        base.RecibirDaņo();
    }
}
