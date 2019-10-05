using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float turnSpeed = 150;
    [SerializeField] private float maxSpeedDelay = 1f;

    private ISnakeController myController;
    private Rigidbody2D myRigidbody2D;
    private bool isMoving = false;
    private bool isAccelerating = false;
    private bool isDecelerating = false;
    private float speedMultiplier = 0f;

    private void Awake() {
        moveSpeed = GameMode.MAX_FORWARD_SPEED;
        turnSpeed = GameMode.TURNING_RATE;
        maxSpeedDelay = GameMode.DELAY_UNTIL_MAXSPEED;

        myRigidbody2D = GetComponent<Rigidbody2D>();
        myController = GetComponent<ISnakeController>();
    }

    private void FixedUpdate()
    {
        if (isMoving) 
        {
            float actualSpeed = moveSpeed;
            if (isAccelerating) {
                speedMultiplier += (Time.fixedDeltaTime / maxSpeedDelay);
                if (speedMultiplier >= 1f) {
                    speedMultiplier = 1f;
                    isAccelerating = false;
                }
                actualSpeed = Mathf.Lerp(0f, moveSpeed, speedMultiplier);
            }

            if (isDecelerating) {
                speedMultiplier -= (Time.fixedDeltaTime / maxSpeedDelay);
                if (speedMultiplier <= 0f) {
                    speedMultiplier = 0f;
                    isDecelerating = false;
                    GetComponent<SnakeHead>().Wait();
                }
                actualSpeed = Mathf.Lerp(0f, moveSpeed, speedMultiplier);
            }

            float input = myController.GetInput();
           
            if (input != 0) {
                myRigidbody2D.SetRotation(myRigidbody2D.rotation - input * turnSpeed * Time.fixedDeltaTime);
            }
            myRigidbody2D.velocity = transform.right * actualSpeed;
        }
        else
        {
            myRigidbody2D.velocity = Vector2.zero;
        }       
    }

    public void DecelerateAndStop() {
        isDecelerating = true;
    }

    public void Stop() {
        isMoving = false;
    }

    public void Resume() {
        isMoving = true;
        isAccelerating = true;
    }

    public bool IsJumping()
    {
        if (isMoving)
        {
            return myController.GetJump();
        }
        else return false;
    }
}
