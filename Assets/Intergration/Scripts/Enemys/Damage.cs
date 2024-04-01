using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
   public int damage = 1; // Daño que inflige el enemigo

    void Update()
    {
        // Detectar la colisión con el jugador utilizando Character Controller
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

        // Si la distancia entre el enemigo y el jugador es menor que un cierto umbral, infligir daño al jugador
        float attackRange = 1.5f; // Definir el rango de ataque del enemigo
        if (distanceToPlayer < attackRange)
        {
            Health playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>(); // Obtener el componente Health del jugador
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Hacer daño al jugador
                Debug.Log("Dano recibido");
            }
        }
    }
}
