using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Damage2D : MonoBehaviour
{
    private GameObject player;
    public Vector2 knockBackPower = new Vector2 (-5, 10);
    public float gravityScale = 5f;
    public float moveForce = 5f;

    public int Health = 100;

    private BarraSalud bs;
    private void Start() {
        player = gameObject;
        bs = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<BarraSalud>();
    }

    private void Update (){
        if (Health <= 0) 
        {
            UIManager.Instance.ActivatePanelLose();
        }
    }
    private void OnCollisionEnter(Collision other) {
         if (other.gameObject.CompareTag("Bomb")){
            IsKnocking();
            Health -= 50;
            bs.health = Health; 
         }
    }
    void IsKnocking ()
    {

        // Ajusta esta variable para controlar la fuerza del retroceso
        float knockbackForce = 5f;

        GameObject playerModel = player.transform.GetChild(0).gameObject; 
        Vector3 moveDirection;

        Rigidbody playerRb = player.GetComponent<Rigidbody>();

        float yStore = player.transform.position.y;
        moveDirection = playerModel.transform.forward * knockBackPower.x ;
        moveDirection.y = yStore;

        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

        Vector3 force = moveDirection * knockbackForce; // Usamos knockbackForce en lugar de moveForce
        playerRb.AddForce(force, ForceMode.Impulse);


    }






}
