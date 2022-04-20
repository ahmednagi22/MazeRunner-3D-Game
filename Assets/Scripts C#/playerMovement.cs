using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed=3;
    public float gravity = -20f;

    public float jumpSpeed = 15;

    private CharacterController controller;

    private Vector3 moveVelocity;

    private Vector3 turnVelocity;
    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        if (controller.isGrounded)
        {
            moveVelocity = transform.right*x*speed+transform.forward *z*speed;
            //turnVelocity = transform.up * rotationSpeed * x;
            if (Input.GetButtonDown("Jump"))
            {
                moveVelocity.y = jumpSpeed;
            }
        }

        moveVelocity.y += gravity * Time.deltaTime;
        controller.Move(moveVelocity*Time.deltaTime);
        

    }
}
