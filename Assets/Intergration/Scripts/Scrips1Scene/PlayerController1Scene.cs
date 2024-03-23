using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1Scene : MonoBehaviour
{

    private static PlayerController1Scene instance;

    public static PlayerController1Scene Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerController1Scene>();
            }
            return instance;
        }
    }
    public CharacterController charController;
    public Animator animator;
    public GameObject playerModel;
    public bool doubleJump = false;
    public float moveSpeed;
    public float garavityScale = 5f;
    public float rotateSpeed = 5f;
    private Vector3 moveDirection;
   
    void Start()
    {
        moveSpeed = 7;
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoPlayer();
        PlayerRun();
    }

    private void MovimientoPlayer()
    {
        float yStore = moveDirection.y;

        // Movimiento
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection.Normalize();
        moveDirection = moveDirection * moveSpeed;
        moveDirection.y = yStore;

        charController.Move(moveDirection * Time.deltaTime);

        moveDirection.y += Physics.gravity.y * Time.deltaTime * garavityScale;

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }
        animator.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));
    }
    void PlayerRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
          moveSpeed = 13;
        }
        else
        {
          moveSpeed = 7;
        }

    }
}
