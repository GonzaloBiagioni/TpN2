using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Enemigo
{
    private void Start()
    {
        moverse();
        Atacar();
    }
    
    public override void moverse()
    {
        base.moverse(); 
    }
     
    public override void RecibirDaño()
    {
        base.RecibirDaño();
    }
    public override void Atacar()
    {
        base.Atacar(); 
    }
}
