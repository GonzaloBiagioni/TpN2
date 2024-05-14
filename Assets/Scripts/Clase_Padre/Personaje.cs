using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Personaje : MonoBehaviour
{
    public int vida;
    public int da�o;
    public int VelocidadMovimiento;

    public abstract void atacar();
    
    public abstract void moverse();

    public abstract void RecibirDa�o();
}
