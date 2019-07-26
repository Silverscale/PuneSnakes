using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour {

    public Player playerPrefab;
    public Transform[] spawnPoint;

    private Transform playerTransform;

    public List<Player> playerList;

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < GameOptions.players; i++)
        {
            playerPrefab = Object.Instantiate<GameObject>(playerPrefab.gameObject).GetComponent<Player>();
            playerTransform = playerPrefab.gameObject.GetComponent<Transform>();

            playerTransform.position = spawnPoint[i].position;
            playerTransform.rotation = spawnPoint[i].rotation;
            Debug.Log("rotation set to: " + playerTransform.rotation);

            playerList.Add(playerPrefab);
            playerPrefab.playerNumber = i;

        }
    }


}
