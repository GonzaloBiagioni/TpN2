using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Enemigo
{
    public override void Atacar()
    {
        base.Atacar(); // esto se usa si el ataque es igual al base
        //acá se agregaría la lógica para que haga su ataque especial
    }

    public override void moverse()
    {
        base.moverse(); // esto se usa si el movimiento es igual al base
        //acá se agregaría la lógica para que haga un movimiento especial de ser necesario
    }
    protected override void MoverVertical()
    {
        base.MoverVertical();
    }

    protected override MoverVerticalCoroutine()
    {
        base.MoverVerticalCoroutine();
    }

    public override void RecibirDaño()
    {
        base.RecibirDaño();
    }
}
