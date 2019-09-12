using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreGame : MonoBehaviour
{
    [SerializeField] private Player playerPrefab = default;

    void Start()
    {
        GameOptions.CheckIfLoaded();
        //Clear the list of players
        Player.ClearPlayerList();
        for (int i = 0; i < GameOptions.players; i++) {
            //Create the players for the match
            Player newPlayer = Object.Instantiate<GameObject>(playerPrefab.gameObject).GetComponent<Player>();
        }
    }
}
