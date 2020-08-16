﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, ISnakeController   {

    private int playerNumber;
    private Player myPlayer;
    private string inputAxis;


    void Start() {
        myPlayer = GetComponentInParent<Player>();
        playerNumber = myPlayer.idNumber;
        inputAxis = "Player" + playerNumber;
    }

    public float GetInput() {
        Debug.Log("Reading input from " + inputAxis);
        return Input.GetAxisRaw(inputAxis);
    }

    public bool GetJump()
    {
        Debug.Log("Getting Jump");

        if (myPlayer.idNumber == 0)
        {
            return Input.GetKeyDown(KeyCode.W);
        }
        else if (myPlayer.idNumber == 1)
        {
            return Input.GetKeyDown(KeyCode.UpArrow);
        }
        else return false;
    }

}