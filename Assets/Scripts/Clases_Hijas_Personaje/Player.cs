using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Personaje, IDamageable, Ihealable
{
    public float moveSpeed = 5f;
    private float velocidadBase;
    public GameObject shurikenPrefab; // Prefab del shuriken que se disparará
    public Transform firePoint; // Punto desde donde se disparará el shuriken

    private Rigidbody2D rb;
    private Vector2 movement;

    // Propiedad para registrar la última dirección de movimiento
    public Vector2 UltimaDireccion { get; private set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocidadBase = moveSpeed; // Guardar la velocidad base al iniciar
    }

    void Update()
    {
        // Lógica de movimiento
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveHorizontal, moveVertical).normalized;

        // Si el jugador se está moviendo, actualizamos la última dirección
        if (movement != Vector2.zero)
        {
            UltimaDireccion = movement;
        }

        // Lógica de ataque
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Atacar();
        }
    }

    void FixedUpdate()
    {
        moverse();
    }

    public override void Atacar()
    {
        // Instanciar un shuriken en el punto de disparo
        if (shurikenPrefab != null && firePoint != null)
        {
            GameObject shuriken = Instantiate(shurikenPrefab, firePoint.position, Quaternion.identity);

            // Obtener el componente del shuriken y pasarle la última dirección del jugador
            Shuriken shurikenScript = shuriken.GetComponent<Shuriken>();
            if (shurikenScript != null)
            {
                shurikenScript.SetDireccion(UltimaDireccion);
            }
        }
    }

    public override void moverse()
    {
        // Lógica de movimiento físico
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public override void RecibirDaño()
    {
        TakeDamage(); // O llamar la lógica de daño adicional si es necesario
    }

    // Implementación de IDamageable
    public void TakeDamage()
    {
        CanvasManager.Instance.PerderHP();
    }

    // Implementación de Ihealable
    public bool RecuperarHP()
    {
        return true;
    }

    public void IncrementarVelocidad(float incremento, float duracion)
    {
        moveSpeed += incremento; // Aumentar la velocidad
        StartCoroutine(RestoreSpeedAfterDelay(duracion)); // Restaurar la velocidad después de la duración
    }

    private IEnumerator RestoreSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        moveSpeed = velocidadBase; // Restaurar la velocidad base
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        IColeccionable coleccionable = other.GetComponent<IColeccionable>();
        if (coleccionable != null)
        {
            coleccionable.Recoger();
        }
    }
}