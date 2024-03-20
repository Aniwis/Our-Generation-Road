using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform spawnPoint; // Punto de origen del proyectil
    public float projectileForce = 20f; // Fuerza de lanzamiento del proyectil

    void Update()
    {
        // Detecta si se presiona el botón de disparo (por ejemplo, el botón izquierdo del mouse)
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(); // Llama a la función Shoot para lanzar el proyectil
        }
    }

    void Shoot()
    {
        // Crea una instancia del proyectil en el punto de origen
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);

        // Obtiene el componente Rigidbody del proyectil
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        // Comprueba si se ha encontrado el componente Rigidbody
        if (rb != null)
        {
            // Aplica una fuerza al proyectil en la dirección hacia adelante del punto de origen
            rb.AddForce(spawnPoint.forward * projectileForce, ForceMode.Impulse);
        }
    }
}
