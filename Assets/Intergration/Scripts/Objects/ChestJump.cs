using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChestJump : MonoBehaviour, IInteractable
{
    public bool isFound = false;
    public Animator animator; // Referencia al componente Animator del cofre
    private bool isOpen = false; // Variable para controlar si el cofre está abierto o cerrado

    private TextMeshProUGUI texto;

    // Método para verificar si el cofre ha sido encontrado

    private void Start()
    {

    }

    public bool IsFound()
    {
        return isFound;
    }

    public void Interact()
    {


        Canvas canvas = transform.GetChild(1).gameObject.GetComponent<Canvas>();
        texto = canvas.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        texto.text = "F para interactuar";

        // Verificar si el cofre ya ha sido encontrado y no está abierto
        if (!isOpen && !isFound && Input.GetKeyDown(KeyCode.F))
        {
            // Marcar el cofre como encontrado
            isFound = true;
            // Desactivar el collider del cofre para evitar que se vuelva a detectar
            GetComponent<Collider>().enabled = false;

            // Activar la animación de abrir el cofre
            animator.SetBool("isOpen", true);
            // Marcar el cofre como abierto
            isOpen = true;
            texto.text = "Obtuviste el salto!";

        }
    }
}
