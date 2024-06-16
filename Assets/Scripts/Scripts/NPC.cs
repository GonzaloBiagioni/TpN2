using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public int Velocidad;
    public delegate void NPCInteractEvent();
    public static event NPCInteractEvent onNPCInteract;
    public static event NPCInteractEvent onNPCExit;

    public void moverse()
    {
        // Lógica para que se mueva.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Jugador entró en la zona del NPC");
            Interactuar();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Jugador salió de la zona del NPC");
            DejarDeInteractuar();
        }
    }

    private void Interactuar()
    {
        onNPCInteract?.Invoke();
    }

    private void DejarDeInteractuar()
    {
        onNPCExit?.Invoke();
    }
}