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
    public float limiteSuperior = 5f; // L�mite superior de movimiento
    public float limiteInferior = -5f; // L�mite inferior de movimiento

    public float velocidadPerseguidor = 5f; // Velocidad de movimiento de perseguidor
    public Transform jugador; // Referencia al transform del jugador
    private float distance;
    public GameObject player;
    public override void Atacar()
    {
        //l�gica para que ataque
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

    public override void RecibirDa�o()
    {
        //l�gica para recibir da�o
    }


    // M�todo para moverse verticalmente de forma infinita
    protected void MoverVertical()
    {
        StartCoroutine(MoverVerticalCoroutine());
    }

    // Corutina para el movimiento vertical infinito
    protected IEnumerator MoverVerticalCoroutine()
    {
        // Variable para controlar la direcci�n del movimiento
        bool moverArriba = true;

        // Loop infinito para moverse verticalmente
        while (true)
        {
            // Si el enemigo alcanza el l�mite superior, cambia de direcci�n
            if (transform.position.y >= limiteSuperior)
            {
                moverArriba = false;
            }
            // Si el enemigo alcanza el l�mite inferior, cambia de direcci�n
            else if (transform.position.y <= limiteInferior)
            {
                moverArriba = true;
            }

            // Mueve el enemigo hacia arriba o hacia abajo seg�n la direcci�n
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


    // M�todo para moverse como perseguidor
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
                // Calcula la direcci�n hacia el jugador y mueve el enemigo hacia �l
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
