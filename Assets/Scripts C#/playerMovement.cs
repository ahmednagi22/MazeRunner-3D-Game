using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private CharacterController controller;
    public Transform groundCheck;
    public float gorundDistance=0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    public float speed = 12f;

    private Vector3 velocity;
    private float verticalVelocity;
    private float jumpForce = 10.0f;
    private float gravity = 14.0f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {   
        
        print(controller.isGrounded);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right*x+transform.forward *z;
        controller.Move(move * speed * Time.deltaTime);
        
        //player jump
        if (controller.isGrounded)
        {   verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            
        }
        Vector3 moveVector = new Vector3(0,verticalVelocity,0);
        controller.Move(moveVector*Time.deltaTime);
        //End of Player Jump
    }
}
