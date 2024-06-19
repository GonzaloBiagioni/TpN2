using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonedaContador : MonoBehaviour
{
    public Text contadorTexto;
    private int contadorMonedas;
    public int valorMoneda = 5;

    private void OnEnable()
    {
        Moneda.onMonedaRecogida += ActualizarContador;
    }

    private void OnDisable()
    {
        Moneda.onMonedaRecogida -= ActualizarContador;
    }

    private void ActualizarContador()
    {
        contadorMonedas = contadorMonedas+ valorMoneda;
        contadorTexto.text = "Monedas: " + contadorMonedas;
    }
}
