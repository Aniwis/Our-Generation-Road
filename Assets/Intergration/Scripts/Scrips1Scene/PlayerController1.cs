using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public bool canRun;


    public float speedForce = 100f;
    public float velocidadRotacion = 10;
    public float velocidadMaxima = 100f;
    private float movementIntensity = 0;

    
    private bool _isGrounded; 
    public Transform _groundCheck;
    public float _groundRadius;
    public LayerMask _whatIsGround;

    public float jumpForce;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); 
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerMovement();
        PlayerAnimation();
        CheckGrounded();
        JumpPlayer ();     
    }
 private void PlayerMovement (){
        
        
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
       
        if ((Input.GetButton("Vertical") || Input.GetButton("Horizontal")) && _isGrounded ) 
       
        {
           
            PlayerRun();

            Vector3 direccion = new Vector3(horizontalInput, 0f, verticalInput).normalized;

             if (direccion != Vector3.zero)
            {
             
                CalculateForward(direccion);
            }

            
            Vector3 speedActual = playerRb.velocity;

             if (speedActual.magnitude > velocidadMaxima)
            {
                playerRb.velocity = speedActual.normalized * velocidadMaxima;
            }
            else 
            {
                playerRb.AddForce(transform.forward * speedForce);
            }
          
        }
        else 
        {
            movementIntensity = 0;
   
            playerRb.velocity = new Vector3(0f, playerRb.velocity.y, 0f);
        }

    }

private void JumpPlayer (){

    if(Input.GetButtonDown("Jump") && _isGrounded ){
       
        playerRb.AddForce(jumpForce * Vector3.up,ForceMode.Impulse);
        
    }

}

private void CalculateForward (Vector3 direccion){

    Quaternion rotacionDeseada = Quaternion.LookRotation(direccion);
    transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, velocidadRotacion);
    playerRb.velocity = new Vector3(0f, playerRb.velocity.y, 0f);

}
private void CheckGrounded()
    {
        _isGrounded = Physics.Raycast(_groundCheck.position, Vector3.down, _groundRadius, _whatIsGround);
    }
void PlayerRun() {
    if (Input.GetKey(KeyCode.LeftShift) && canRun){
        velocidadMaxima = 70;
        speedForce = 70;
        movementIntensity = 1;
    }
    else {
        movementIntensity = 0.5f;
        speedForce = 35;
        velocidadMaxima = 35;
    }

}
    // Método para determinar si el jugador está caminando, corriendo o parado
private void PlayerAnimation() {

    playerAnim.SetFloat("Speed" ,movementIntensity );
    playerAnim.SetBool("IsGrounded" ,_isGrounded );
}
    

 private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if(_isGrounded){
            Gizmos.DrawWireSphere(_groundCheck.position - Vector3.up * _groundRadius, _groundRadius);
        }
        
    }

}
