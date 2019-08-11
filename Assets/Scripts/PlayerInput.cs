using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, ISnakeController   {

    private int playerNumber;
    private Player myPlayer;
    private string inputAxis;


    void Start() {
        myPlayer = GetComponentInParent<Player>();
        playerNumber = myPlayer.playerNumber;
        inputAxis = "Player" + playerNumber;
    }

    public float GetInput() {
        Debug.Log("Reading input from " + inputAxis);
        return Input.GetAxis(inputAxis);
    }
}