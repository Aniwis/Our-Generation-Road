using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 5; // Vida máxima del jugador
    private int currentHealth; // Vida actual del jugador

    public GameObject gameOverPanel; // Referencia al panel de Game Over

    void Start()
    {
        currentHealth = maxHealth; // Al iniciar, la vida actual es igual a la vida máxima
        // Desactivar el panel de Game Over al inicio
        gameOverPanel.SetActive(false);
    }

    // Función para reducir la salud del jugador
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reducir la vida del jugador según el daño recibido

        if (currentHealth <= 0)
        {
            currentHealth = 0; // Asegurarse de que la salud no sea negativa
            Debug.Log("¡Perdiste!"); // Mostrar mensaje de que el jugador perdió
            // Aquí podrías llamar a una función para manejar la derrota, cargar un menú de juego, etc.
            gameOverPanel.SetActive(true);
        }
    }
}
