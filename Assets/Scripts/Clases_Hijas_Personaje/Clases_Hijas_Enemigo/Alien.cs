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
     
    public override void RecibirDaño()
    {
        base.RecibirDaño();
    }
    public override void Atacar()
    {
        base.Atacar(); // esto se usa si el ataque es igual al base
        //acá se agregaría la lógica para que haga su ataque especial
    }
}
