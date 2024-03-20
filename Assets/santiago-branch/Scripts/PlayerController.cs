using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5f;
    public float velocidadRotacion = 10;
    public float velocidadMaxima = 5f;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        PlayerMovement();        
    }

    void PlayerMovement() {

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
      

        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            Vector3 direccion = new Vector3(horizontalInput, 0f, verticalInput).normalized;

            if (direccion != Vector3.zero)
            {

                Quaternion rotacionDeseada = Quaternion.LookRotation(direccion);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, Time.deltaTime * velocidadRotacion);

                // Detener la velocidad del jugador
                playerRb.velocity = Vector3.zero;
            }

            
            // Calcula la velocidad actual del objeto controlado por el jugador
            Vector3 velocidadActual = playerRb.velocity;

            // Limita la velocidad a la velocidad máxima si se supera
            if (velocidadActual.magnitude > velocidadMaxima)
            {
                // Reduzca la velocidad a la velocidad máxima manteniendo la dirección
                playerRb.velocity = velocidadActual.normalized * velocidadMaxima;
            }
            else
            {
                // Añade la fuerza solo si la velocidad actual es menor que la velocidad máxima
                playerRb.AddForce(transform.forward * speed);
            }

        }
        

      


    }

    


}
