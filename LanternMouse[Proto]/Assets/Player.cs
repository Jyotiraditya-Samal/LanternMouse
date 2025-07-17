using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public Transform playerTrans;

    public float walkSpeed = 90;
    public float backwardSpeed = 90;
    public float runSpeed = 140;
    public float rotationSpeed = 100;

    private bool isWalking = false;
    private bool isRunning = false;

    void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.zero;

        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0.1)
        {
            moveDirection += transform.forward * (isRunning ? runSpeed : walkSpeed);
        }

        if (verticalInput < -0.1)
        {
            moveDirection -= transform.forward * backwardSpeed;
        }

        playerRigid.velocity = moveDirection * Time.fixedDeltaTime;
    }

    void Update()
    {
        // Handle rotation via left stick X-axis
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput < -0.1f)
        {
            playerTrans.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        if (horizontalInput > 0.1f)
        {
            playerTrans.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Handle animation logic
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0.1f && !isWalking)
        {
            playerAnim.SetTrigger("Walk");
            playerAnim.ResetTrigger("Idle");
            isWalking = true;
        }

        if (verticalInput < 0.1f && isWalking && !Input.GetKey(KeyCode.JoystickButton5))
        {
            playerAnim.ResetTrigger("Walk");
            playerAnim.SetTrigger("Idle");
            isWalking = false;
        }

        // Run input using R trigger (JoystickButton5)
        if (Input.GetKeyDown(KeyCode.JoystickButton5) && isWalking)
        {
            playerAnim.ResetTrigger("Walk");
            playerAnim.SetTrigger("Run");
            isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.JoystickButton5))
        {
            playerAnim.ResetTrigger("Run");

            if (isWalking)
                playerAnim.SetTrigger("Walk");
            else
                playerAnim.SetTrigger("Idle");

            isRunning = false;
        }
    }
}
