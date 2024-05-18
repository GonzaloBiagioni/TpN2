using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHP : MonoBehaviour
{
 //   public Slider slider;

    void Start()
    {
        //slider = GetComponent<Slider>();
    }

    public void cambiarVidaMaxima(float vidaMaxima)
    {
     //   slider.maxValue = vidaMaxima;
    }

    public void cambiarVidaActual(float cantidadVida)
    {
//        slider.value = cantidadVida;
    }

    public void inicializarBarraDeVida(float cantidadVida)
    {
        cambiarVidaMaxima(cantidadVida);
        cambiarVidaActual(cantidadVida);
    }
}
