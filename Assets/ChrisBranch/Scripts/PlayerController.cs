using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator animator;
    public float speed = 100f;
    public float velocidadRotacion = 10;
    public float velocidadMaxima = 100f;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerMovement(); 
        PlayerAnimation();       
    }

    void PlayerMovement() {

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
      

        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            PlayerRun();
            IsMoving = true;
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
        else
        {
            IsMoving = false;
        }

      


    }

    private bool IsMoving = false;
     private bool IsRunning = false;

    void PlayerRun()
    {
        if (Input.GetKey(KeyCode.Space)){
            speed = 150;
            velocidadMaxima = 200;
            IsRunning = true;
        }
        else 
        {
            speed = 100;
            velocidadMaxima = 100;
            IsRunning = false;
        }
    }

    void PlayerAnimation(){

        animator.SetBool("IsMoving", IsMoving);
        animator.SetBool("IsRunning", IsRunning);

    } 

}
