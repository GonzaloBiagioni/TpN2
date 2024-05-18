using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CanvasManager.Instance.RecuperarHP();
            Destroy(this.gameObject);
        }
    }
}
