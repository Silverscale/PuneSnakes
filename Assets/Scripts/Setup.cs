using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour {

    public PlayerInput playerPrefab;
    public Transform[] spawnPoint;
    //public Collider headCollider;
    //public Collider bodyCollider;

    private Transform player;

	// Use this for initialization
	void Start ()
    {

        for (int i = 0; i < spawnPoint.Length; i++)
        {
            player = Object.Instantiate<GameObject>(playerPrefab.gameObject).GetComponent<Transform>();
            //bodyCollider.enabled = false;
            //headCollider.enabled = true;

            player.position = spawnPoint[i].position;
            player.rotation = spawnPoint[i].rotation;
            Debug.Log("rotation set to: " + player.rotation);

        }
    }
	
}
