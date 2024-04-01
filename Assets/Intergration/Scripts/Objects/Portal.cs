using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour, IInteractable
{

    public GameObject winPanel; // Referencia al panel de "Ganaste"


    public void Interact()
    {
        // Activamos el panel de "Ganaste" cuando el jugador interactúa con el portal
        winPanel.SetActive(true);
    }
}
