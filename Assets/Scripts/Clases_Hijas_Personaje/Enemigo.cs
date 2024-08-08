using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : Personaje
{
    public GameObject proyectilPrefab; // Asignar en el inspector el prefab del proyectil
    public Transform puntoDeDisparo; // Asignar en el inspector el punto de disparo

    public bool MovimientoVertical = false;
    public bool MovimientoPerseguidor = false;

    public float velocidad = 2f; // Velocidad de movimiento
    public float limiteSuperior = 5f; // Límite superior de movimiento
    public float limiteInferior = -5f; // Límite inferior de movimiento

    public float velocidadPerseguidor = 5f; // Velocidad de movimiento de perseguidor
    private float distance;
    public float distanciaPersecucion;
    public GameObject player;

    public float tiempoEntreDisparos = 2f; // Intervalo de tiempo entre disparos en segundos
    private bool disparando = false;

    public override void Atacar()
    {
        if (!disparando)
        {
            disparando = true;
            StartCoroutine(DispararAutomaticamente());
        }
    }

    protected virtual IEnumerator DispararAutomaticamente()
    {
        while (true)
        {
            DispararProyectil();
            yield return new WaitForSeconds(tiempoEntreDisparos);
        }
    }

    protected virtual void DispararProyectil()
    {
        if (proyectilPrefab != null && puntoDeDisparo != null)
        {
            Instantiate(proyectilPrefab, puntoDeDisparo.position, transform.rotation);
        }
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
        // Lógica para recibir daño
    }

    // Método para moverse verticalmente de forma infinita
    protected virtual void MoverVertical()
    {
        StartCoroutine(MoverVerticalCoroutine());
    }

    // Corutina para el movimiento vertical infinito
    protected virtual IEnumerator MoverVerticalCoroutine()
    {
        bool moverArriba = true;

        while (true)
        {
            if (transform.position.y >= limiteSuperior)
            {
                moverArriba = false;
            }
            else if (transform.position.y <= limiteInferior)
            {
                moverArriba = true;
            }

            if (moverArriba)
            {
                transform.Translate(Vector3.up * velocidad * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.down * velocidad * Time.deltaTime);
            }

            yield return null;
        }
    }

    // Método para moverse como perseguidor
    public void MoverPerseguidor()
    {
        StartCoroutine(MoverPerseguidorCoroutine());
    }

    // Corutina para el movimiento de perseguidor
    public IEnumerator MoverPerseguidorCoroutine()
    {
        while (true)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < distanciaPersecucion)
            {
                Vector2 direction = (player.transform.position - transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocidadPerseguidor * Time.deltaTime);
            }

            yield return null;
        }
    }
}
