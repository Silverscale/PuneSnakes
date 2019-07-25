using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour {

    public Player playerPrefab;
    public Transform[] spawnPoint;

    private Transform player;

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < GameOptions.players; i++)
        {
            player = Object.Instantiate<GameObject>(playerPrefab.gameObject).GetComponent<Transform>();

            player.position = spawnPoint[i].position;
            player.rotation = spawnPoint[i].rotation;
            Debug.Log("rotation set to: " + player.rotation);

        }
    }
}
