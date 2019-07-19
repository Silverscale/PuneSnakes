using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float moveSpeed = 1;
    public float turnSpeed = 150;

    private ISnakeController myController;
    private Rigidbody2D myRigidbody2D;

    private void Awake() {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myController = GetComponent<ISnakeController>();
        Debug.Log("Player " + myController.PlayerNumber() +
            " is going to read from: Player" + myController.PlayerNumber());
    }

    private void FixedUpdate()
    {
        float input = myController.GetInput();
        if (input != 0)
        {
            myRigidbody2D.SetRotation(myRigidbody2D.rotation + input * turnSpeed * Time.fixedDeltaTime);
            //gameObject.transform.Rotate(Vector3.up, turnSpeed * input * Time.fixedDeltaTime);
        }
        myRigidbody2D.velocity = transform.forward * moveSpeed * Time.fixedDeltaTime;
        //gameObject.transform.localPosition += gameObject.transform.forward * moveSpeed * Time.fixedDeltaTime;
    }
}
