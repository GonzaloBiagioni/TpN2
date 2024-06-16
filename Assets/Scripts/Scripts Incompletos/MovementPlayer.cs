using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementPlayer : MonoBehaviour, iDamageable

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
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveHorizontal, moveVertical).normalized;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Implementación de IDamageable
    public void TakeDamage()
    {
        CanvasManager.Instance.PerderHP();
    }
}
public interface iDamageable
{
    void TakeDamage();
}
/*
 *     [Header("Bala Player")]
    public GameObject bala ;
    public Transform firepoint;
    public float fireRate = 15f;
    private float nextFireTime = 0.5f;
    [Header ("HP Player")]
    public float vida;
    public float maximoVida;
    public BarraHP barraDeVida;
/ * void FixedUpdate()
  {
      rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
  }
          // Disparo
      if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime)
      {
          AudioManager.Instance.PlaySFX(3);
          Shoot();
  nextFireTime = Time.time + 2f / fireRate;
      }
  }

  // Disparo
  private void Shoot()
{
  Instantiate(bala, firepoint.position, firepoint.rotation);
}

// HP, pausa y cambio de escena

private void OnTriggerEnter2D(Collider2D other)
{
  if (other.CompareTag("Enemigo"))
  {
      AudioManager.Instance.PlaySFX(1);
      vida -= 1f;
      barraDeVida.cambiarVidaActual(vida);
      if (vida <= 0)
      {
          Time.timeScale = 0f;
          gameObject.SetActive(false);
          SceneManager.LoadScene(2);
      }
  }
}
*/
