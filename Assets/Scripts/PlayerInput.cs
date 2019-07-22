using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, ISnakeController   {

    private int playerNumber;

    public void Awake()
    {
        playerNumber = FindObjectsOfType<PlayerInput>().Length;
        Debug.Log("Created player " + playerNumber);
    }

    public int PlayerNumber() {
        return playerNumber;
    }

    public float GetInput() {
        return Input.GetAxis("Player" + playerNumber);
    }
}