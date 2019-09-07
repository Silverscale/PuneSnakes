using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float turnSpeed = 150;

    private ISnakeController myController;
    private Rigidbody2D myRigidbody2D;
    private bool isMoving = false;
    private bool justSpawned = true;
    private int framesCounter;

    private void Awake() {
        moveSpeed = GameOptions.forward;
        turnSpeed = GameOptions.turning;
        framesCounter = GameOptions.framesBehind;

        myRigidbody2D = GetComponent<Rigidbody2D>();
        myController = GetComponent<ISnakeController>();
    }

    private void FixedUpdate()
    {
        CheckIfIShouldStartMoving();
        if (isMoving) 
        {
            float input = myController.GetInput();
            if (input != 0) {
                myRigidbody2D.SetRotation(myRigidbody2D.rotation - input * turnSpeed * Time.fixedDeltaTime);
            }
            myRigidbody2D.velocity = transform.right * moveSpeed;
        }
        else
        {
            myRigidbody2D.velocity = Vector2.zero;
        }
    }

    private void CheckIfIShouldStartMoving() {
        if (!isMoving && justSpawned && framesCounter == 0) {
            Resume();
        }
        else if (framesCounter > 0) {
            framesCounter--;
        }
    }

    public void Stop() {
        isMoving = false;
        justSpawned = false; // this should stop CheckIfIShouldStartMoving from reactivating a dead chunk
    }

    public void Resume() {
        isMoving = true;
        justSpawned = false;
    }
}
