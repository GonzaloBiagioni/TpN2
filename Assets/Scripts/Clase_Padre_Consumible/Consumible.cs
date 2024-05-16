using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumible : MonoBehaviour
{
    public virtual void Destruir()
    {
        Destroy(gameObject);
    }

}
