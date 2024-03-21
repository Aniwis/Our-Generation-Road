using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 10f; // Velocidad del proyectil

    void Update()
    {
        // Mover el proyectil hacia adelante
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisión fue con un enemigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destruir al enemigo
            Destroy(collision.gameObject);

            // Destruir el proyectil actual (este objeto)
            Destroy(gameObject);
        }
    }
}
