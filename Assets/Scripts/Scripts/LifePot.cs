using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CanvasManager canvasManager = CanvasManager.Instance;

            if (canvasManager != null)
            {
                bool vidaRecuperada = canvasManager.RecuperarHP();

                if (vidaRecuperada)
                {
                    Destroy(gameObject); 
                }
            }
        }
    }
}