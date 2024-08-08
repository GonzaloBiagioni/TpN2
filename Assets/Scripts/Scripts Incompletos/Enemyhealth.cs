using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    public int vida = 1; // Los enemigos normales tienen solo 1 de vida

    public void TakeDamage(int damage)
    {
        vida -= damage;

        if (vida <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        Destroy(gameObject);
    }
}