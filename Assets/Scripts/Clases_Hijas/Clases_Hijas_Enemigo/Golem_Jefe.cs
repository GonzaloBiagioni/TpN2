using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_Jefe : Enemigo
{
    public override void atacar()
    {
        base.atacar(); // esto se usa si el ataque es igual al base
        //ac� se agregar�a la l�gica para que haga su ataque especial
    }

    public override void moverse()
    {
        base.moverse(); // esto se usa si el movimiento es igual al base
        //ac� se agregar�a la l�gica para que haga un movimiento especial de ser necesario
    }

    public override void RecibirDa�o()
    {
        base.RecibirDa�o();
    }
}
