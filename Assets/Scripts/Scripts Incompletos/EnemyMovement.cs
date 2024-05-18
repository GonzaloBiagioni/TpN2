using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween;

    private float distance;

    void Start()
    {
        
    }

    void Update()
    {

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        if(distance < 10)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
    public float velocidad = 2f;
    public int daño = 1;
    public GameObject prefabMoneda;
    public float tiempoDestruccion = 0f;

    void start()
    {
        // Enemigo sigue al jugador
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");

        if (jugador != null)
        {
            Vector3 direccion = jugador.transform.position - transform.position;
            direccion.z = 0f;
            transform.Translate(direccion.normalized * velocidad * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            // Enemigo impacta al jugador
            JugadorImpactado(otro.GetComponent<Player>());
        }
        else if (otro.CompareTag("Bala Player"))
        {
            // Enemigo impactado por una bala
            BalaImpactada(otro.gameObject);
        }
    }

    void JugadorImpactado(Player jugador)
    {
        // Restar vida al jugador
        CanvasHP barraHPJugador = jugador.GetComponentInChildren<CanvasHP>();

        if (barraHPJugador != null)
        {
          //  barraHPJugador.cambiarVidaActual(barraHPJugador.slider.value - daño);
        }
        // Destruir el enemigo
        DestruirEnemigo();
    }
    void BalaImpactada(GameObject bala)
    {
        // Destruir la bala
        Destroy(bala);

        // Soltar monedas
        SoltarMonedas();

        // Destruir el enemigo
        DestruirEnemigo();
    }

    void SoltarMonedas()
    {
        // Instanciar monedas
        if (prefabMoneda != null)
        {
            Instantiate(prefabMoneda, transform.position, Quaternion.identity);
        }
    }

    void DestruirEnemigo()
    {
        // Destruir el enemigo después de un tiempo
        Destroy(gameObject, tiempoDestruccion);
    }
}

