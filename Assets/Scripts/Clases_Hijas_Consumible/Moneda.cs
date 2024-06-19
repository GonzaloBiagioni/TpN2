using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moneda : MonoBehaviour, IColeccionable
{
    public delegate void MonedaRecogidaEventHandler();
    public static event MonedaRecogidaEventHandler onMonedaRecogida;

    public void Recoger()
    {
        // Destruye la moneda y lanza el evento
        onMonedaRecogida?.Invoke();
        Destroy(gameObject);
    }
}
