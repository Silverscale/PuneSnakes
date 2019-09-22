using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreGame : MonoBehaviour
{
    [SerializeField] private Player playerPrefab = default;

    void Start()
    {
        GameOptions.CheckIfLoaded();
    }

    public void CreatePlayers() {
        GameOptions.SavePlayers();
        //Clear the list of players
        Player.ClearPlayerList();
        for (int i = 0; i < GameOptions.isPlayerSelected.Length; i++) {
            //Create the players for the match
            if (GameOptions.isPlayerSelected[i]) {
                Player newPlayer = Object.Instantiate<GameObject>(playerPrefab.gameObject).GetComponent<Player>();
                newPlayer.SetNumber(i);
                Debug.Log("Manually assigned player number");
                //TODO tell the player wich is his number
            }
        }
    }
}
