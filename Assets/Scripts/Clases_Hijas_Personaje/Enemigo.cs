using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : Personaje
{
    // Booleano para controlar el tipo de movimiento del enemigo
    public bool MovimientoVertical = false;
    public bool MovimientoPerseguidor = false;

    public float velocidad = 2f; // Velocidad de movimiento
    public float limiteSuperior = 5f; // Límite superior de movimiento
    public float limiteInferior = -5f; // Límite inferior de movimiento

    public float velocidadPerseguidor = 5f; // Velocidad de movimiento de perseguidor
    public Transform jugador; // Referencia al transform del jugador
    private float distance;
    public GameObject player;
    public override void Atacar()
    {
        //lógica para que ataque
    }

    public override void moverse()
    {
        if (MovimientoVertical)
        {
            MoverVertical();
        }
        if (MovimientoPerseguidor)
        {
            MoverPerseguidor();
        }
    }

    public override void RecibirDaño()
    {
        //lógica para recibir daño
    }


    // Método para moverse verticalmente de forma infinita
    protected void MoverVertical()
    {
        StartCoroutine(MoverVerticalCoroutine());
    }

    // Corutina para el movimiento vertical infinito
    protected IEnumerator MoverVerticalCoroutine()
    {
        // Variable para controlar la dirección del movimiento
        bool moverArriba = true;

        // Loop infinito para moverse verticalmente
        while (true)
        {
            // Si el enemigo alcanza el límite superior, cambia de dirección
            if (transform.position.y >= limiteSuperior)
            {
                moverArriba = false;
            }
            // Si el enemigo alcanza el límite inferior, cambia de dirección
            else if (transform.position.y <= limiteInferior)
            {
                moverArriba = true;
            }

            // Mueve el enemigo hacia arriba o hacia abajo según la dirección
            if (moverArriba)
            {
                transform.Translate(Vector3.up * velocidad * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.down * velocidad * Time.deltaTime);
            }

            // Espera un frame antes de continuar
            yield return null;
        }
    }


    // Método para moverse como perseguidor
    protected void MoverPerseguidor()
    {
        StartCoroutine(MoverPerseguidorCoroutine());
    }

    // Corutina para el movimiento de perseguidor
    protected IEnumerator MoverPerseguidorCoroutine()
    {
        // Loop infinito para el movimiento de perseguidor
        while (true)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);

            while (distance < 10)
            {
                // Calcula la dirección hacia el jugador y mueve el enemigo hacia él
                Vector2 direction = player.transform.position - transform.position;
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocidadPerseguidor * Time.deltaTime);

                ;

                // Actualiza la distancia al jugador
                distance = Vector2.Distance(transform.position, player.transform.position);
            }
            // Espera un frame antes de continuar
            yield return null;
        }
    }


}
