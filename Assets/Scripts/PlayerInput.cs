using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, ISnakeController   {
 
    public GameObject bodyChunk;

    private int playerNumber;

    private Transform body;
    private readonly string wallTag = "Obstacle";

    public void Awake()
    {
        playerNumber = FindObjectsOfType<PlayerInput>().Length;
        Debug.Log("Created player " + playerNumber);
        body = GameObject.Instantiate(bodyChunk, gameObject.transform, false).GetComponent<Transform>();
    }

    public int PlayerNumber() {
        return playerNumber;
    }

    public float GetInput() {
        return Input.GetAxis("Player" + playerNumber);
    }

    /*
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(wallTag))
        {
            gameObject.SetActive(false);
        }
    }
    */
}