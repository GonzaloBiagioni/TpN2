using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Personaje, IDamageable, Ihealable
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Lógica de movimiento
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveHorizontal, moveVertical).normalized;
    }

    void FixedUpdate()
    {
        moverse();
    }

    public override void Atacar()
    {
        // Lógica para que ataque
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        IColeccionable coleccionable = other.GetComponent<IColeccionable>();
        if (coleccionable != null)
        {
            coleccionable.Recoger();
        }
    }
}
