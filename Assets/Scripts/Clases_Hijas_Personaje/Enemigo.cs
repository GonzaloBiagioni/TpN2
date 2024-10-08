using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : Personaje
{
    public GameObject proyectilPrefab; // Asignar en el inspector el prefab del proyectil
    public Transform puntoDeDisparo; // Asignar en el inspector el punto de disparo
    public GameObject coinPrefab;
    public bool MovimientoVertical = false;
    public bool MovimientoPerseguidor = false;

    public float velocidad = 2f; // Velocidad de movimiento
    public float limiteSuperior = 5f; // L�mite superior de movimiento
    public float limiteInferior = -5f; // L�mite inferior de movimiento

    public float velocidadPerseguidor = 5f; // Velocidad de movimiento de perseguidor
    private float distance;
    public float distanciaPersecucion;

    public float tiempoEntreDisparos = 2f; // Intervalo de tiempo entre disparos en segundos
    private bool disparando = false;

    public GameObject player;
    public GameManager gameManager;

    private void Start()
    {
        // Encuentra el GameManager en la escena
        gameManager = FindObjectOfType<GameManager>();
    }

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

    public override void RecibirDa�o()
    {
        vida -= 1;

        if (vida <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        // Verifica si el nombre del objeto es "Jefe"
        if (gameObject.name == "Jefe")
        {
            if (gameManager != null)
            {
                gameManager.CambiarAEscenaVictoria();
            }
            else
            {
                Debug.LogWarning("GameManager no encontrado");
            }
        }
        Destroy(gameObject); 
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
    }

    // M�todo para moverse verticalmente de forma infinita
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

    // M�todo para moverse como perseguidor
    public void MoverPerseguidor()
    {
        Debug.Log("movimiento");
        Debug.Log("hola");
        // Encuentra al jugador por su nombre
        player = GameObject.Find("Player");

        if (player == null)
        {
            Debug.LogError("El GameObject con el nombre 'NombreDelJugador' no fue encontrado en el m�todo Start.");
        }
        else
        {
            Debug.Log("Jugador encontrado por nombre en Start.");
        }
        StartCoroutine(MoverPerseguidorCoroutine());
    }

    // Corutina para el movimiento de perseguidor
    public IEnumerator MoverPerseguidorCoroutine()
    {
        while (true)
        {
            Debug.Log("while");
            if (player != null)
            {
                Debug.Log("hay jugador");
                distance = Vector2.Distance(transform.position, player.transform.position);

                if (distance < distanciaPersecucion)
                {
                    Vector2 direction = (player.transform.position - transform.position).normalized;
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocidadPerseguidor * Time.deltaTime);
                }
            }
            else
            { Debug.Log("NOUP"); }

            yield return null;
        }
    }
}