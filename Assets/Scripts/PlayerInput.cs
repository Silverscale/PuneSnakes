using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, ISnakeController   {

    private int playerNumber;
    private Player myPlayer;
    private string inputAxis;
    private float lastInput = 1f;

    void Start() {
        myPlayer = GetComponentInParent<Player>();
        playerNumber = myPlayer.playerNumber;
        inputAxis = "Player" + playerNumber;
    }

    public float GetInput() {
        Debug.Log("Reading input from " + inputAxis);
        float input = Input.GetAxisRaw(inputAxis);
        if (Mathf.Abs(input) < 0.2f) {
            input = lastInput;
        }
        else {
            lastInput = input;
        }

        return input;
    }

    public bool GetJump()
    {
        Debug.Log("Getting Jump");

        if (myPlayer.playerNumber == 0)
        {
            return Input.GetKeyDown(KeyCode.W);
        }
        else if (myPlayer.playerNumber == 1)
        {
            return Input.GetKeyDown(KeyCode.UpArrow);
        }
        else return false;
    }

}