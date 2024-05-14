using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Personaje : MonoBehaviour
{
    public int vida;
    public int daño;
    public int VelocidadMovimiento;

    public abstract void atacar();
    
    public abstract void moverse();

    public abstract void RecibirDaño();
}
