using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
 
    public GameObject bodyChunk;

    public int PlayerNumber    {
        get; private set;
    }

    private Transform body;
    private readonly string wallTag = "Obstacle";

    public void Awake()
    {
        PlayerNumber = FindObjectsOfType<PlayerController>().Length;
        Debug.Log("Created player " + PlayerNumber);
        body = GameObject.Instantiate(bodyChunk, gameObject.transform, false).GetComponent<Transform>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(wallTag))
        {
            gameObject.SetActive(false);
        }
    }
}