using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Enemigo
{
    private void Start()
    {
        moverse();
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
        base.Atacar(); // esto se usa si el ataque es igual al base
        //ac� se agregar�a la l�gica para que haga su ataque especial
    }
}
