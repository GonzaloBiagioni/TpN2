using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHP: MonoBehaviour
{
    public GameObject[] hp;

    public void DesactivarHP(int indice)
    {
        if (indice >= 0 && indice < hp.Length)
        {
            hp[indice].SetActive(false);
        }
        else
        {
            Debug.LogError("�ndice fuera de los l�mites del array hp en DesactivarHP. �ndice: " + indice + ", Longitud del array: " + hp.Length);
        }
    }

    public void ActivarHP(int indice)
    {
        if (indice >= 0 && indice < hp.Length)
        {
            hp[indice].SetActive(true);
        }
        else
        {
            Debug.LogError("�ndice fuera de los l�mites del array hp en ActivarHP. �ndice: " + indice + ", Longitud del array: " + hp.Length);
        }
    }
}