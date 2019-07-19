using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1;
    public float turnSpeed = 150;

    private PlayerController pc;

    private void Start()
    {
        pc = GetComponent<PlayerController>();
        Debug.Log("Player " + pc.PlayerNumber + " is going to read from: Player" + pc.PlayerNumber);
    }

    private void FixedUpdate()
    {
        float playerInput = Input.GetAxis("Player" + pc.PlayerNumber);
        if ( playerInput != 0)
        {
            gameObject.transform.Rotate(Vector3.up, turnSpeed * playerInput * Time.fixedDeltaTime);
        }
        gameObject.transform.localPosition += gameObject.transform.forward * moveSpeed * Time.fixedDeltaTime;
    }
}
