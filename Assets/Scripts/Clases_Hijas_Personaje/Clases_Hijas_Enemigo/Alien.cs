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
     
    public override void RecibirDa�o()
    {
        base.RecibirDa�o();
    }
    public override void Atacar()
    {
        base.Atacar(); 
    }
}
