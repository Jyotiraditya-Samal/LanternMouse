using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public Transform playerTrans;

    public float walkSpeed = 3f;
    public float backwardSpeed = 2f;
    public float runSpeed = 6f;
    public float rotationSpeed = 100f;

    private bool isWalking = false;
    private bool isRunning = false;

    void FixedUpdate()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward * (isRunning ? runSpeed : walkSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= transform.forward * backwardSpeed;
        }

        playerRigid.velocity = moveDirection * Time.fixedDeltaTime;
    }

    void Update()
    {
        // Handle rotation
        if (Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Animation and movement input
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("Walk");
            playerAnim.ResetTrigger("Idle");
            isWalking = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("Walk");
            playerAnim.SetTrigger("Idle");
            isWalking = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("Walk");
            playerAnim.ResetTrigger("Idle");
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("Walk");
            playerAnim.SetTrigger("Idle");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && isWalking)
        {
            playerAnim.ResetTrigger("Walk");
            playerAnim.SetTrigger("Run");
            isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
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
