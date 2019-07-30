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
            Player newPlayer = Object.Instantiate<GameObject>(playerPrefab.gameObject).GetComponent<Player>();
            playerTransform = newPlayer.gameObject.GetComponent<Transform>();
            playerTransform.localScale = Vector3.one * GameOptions.snakeScale;
            playerTransform.position = spawnPoint[i].position;
            playerTransform.rotation = spawnPoint[i].rotation;
            Debug.Log("rotation set to: " + playerTransform.rotation);

            playerList.Add(newPlayer);
            newPlayer.playerNumber = i;
            DisablePlayer(newPlayer);
        }
    }

    private void DisablePlayer(Player player) {
        player.GetComponent<Player>().enabled = false;
        player.GetComponent<SnakeMovement>().Stop();
    }

    private void EnablePlayer(Player player) {
        player.GetComponent<Player>().enabled = true;
        player.GetComponent<SnakeMovement>().Resume();
    }


    public void StartRound() {
        foreach (Player player in playerList) {
             EnablePlayer(player);
        }
    }

}
