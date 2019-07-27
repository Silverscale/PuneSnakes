using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, ISnakeController   {

    private int playerNumber;

    public void Start()
    {
        Player myPlayer = GetComponent<Player>();
        playerNumber = myPlayer.playerNumber;
        Debug.Log("Created player " + playerNumber);
    }

    public int PlayerNumber() {
        return playerNumber;
    }

    public float GetInput() {
        return Input.GetAxis("Player" + playerNumber);
    }
}