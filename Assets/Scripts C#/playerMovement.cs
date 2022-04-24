using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public Slider PlayerHealth;
    private Boolean levelOver = false;
    private int MAX_HEALTH = 3;
    private float timeValue = 180; //Left Time

    public float speed = 3;
    public float gravity = -20f;

    public float jumpSpeed = 15;

    private CharacterController controller;

    private Vector3 moveVelocity;

    private Vector3 turnVelocity;
    // Start is called before the first frame update

    void Start()
    {
        controller = GetComponent<CharacterController>();
        PlayerHealth.value = MAX_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        //to not print time in minus 
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);
        if (timeValue == 0 && !PuaseMenu.GameIsPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(5);

        }

        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        if (controller.isGrounded)
        {
            moveVelocity = transform.right * x * speed + transform.forward * z * speed;
            //turnVelocity = transform.up * rotationSpeed * x;
            if (Input.GetButtonDown("Jump"))
            {
                moveVelocity.y = jumpSpeed;
            }
        }

        moveVelocity.y += gravity * Time.deltaTime;
        controller.Move(moveVelocity * Time.deltaTime);


    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        if (minutes < 1)
        {
            timerText.color = Color.red;

        }

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log(collision.gameObject.name);
            PlayerHealth.value -= 1;
            // Destroy(collision.gameObjec
        }
    }
}
