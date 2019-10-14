using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, ISnakeController   {

    private int playerNumber;
    private Player myPlayer;
    private string inputAxis;
    private string inputAction;


    void Start() {
        myPlayer = GetComponentInParent<Player>();
        playerNumber = myPlayer.playerNumber;
        inputAxis = "Player" + playerNumber;
        inputAction = "Fire" + playerNumber;
    }

    public float GetInput() {
        //Debug.Log("Reading input from " + inputAxis);
        return Input.GetAxisRaw(inputAxis);
    }

    public bool GetJump()
    {
        //Debug.Log("Getting Jump");
        return Input.GetKeyDown(inputAction);
    }

}