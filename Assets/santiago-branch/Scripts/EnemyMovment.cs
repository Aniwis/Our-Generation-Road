using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    private Rigidbody enemyRb;
    private Transform player;
    private Animator animator;

    public float moveSpeed = 5f; // Velocidad de movimiento del enemigo
    public float rotationSpeed = 2f; // Velocidad de rotación del enemigo
    public float detectionRange = 10f; // Rango de detección del jugador

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogWarning("No se encontró el GameObject con la etiqueta 'Player'. Asegúrate de asignar la etiqueta correctamente.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRange)
            {
                // Rotar hacia el jugador
                RotateTowardsPlayer();

                // Mover hacia el jugador
                MoveTowardsPlayer();

                // Actualizar la animación
                UpdateAnimation(true);
            }
            else
            {
                // Detener el movimiento si el jugador está fuera del rango de detección
                enemyRb.velocity = Vector3.zero;

                // Actualizar la animación
                UpdateAnimation(false);
            }
        }
    }

    void RotateTowardsPlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }

    void MoveTowardsPlayer()
    {
        Vector3 moveDirection = (player.position - transform.position).normalized;
        enemyRb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);
    }

    void UpdateAnimation(bool isChasing)
    {
        animator.SetBool("IsRunning", isChasing);
        animator.SetBool("IsMoving", isChasing);
    }
}
