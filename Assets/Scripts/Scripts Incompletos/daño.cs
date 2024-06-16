using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        iDamageable damageable = other.gameObject.GetComponent<iDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage();
        }
    }
}