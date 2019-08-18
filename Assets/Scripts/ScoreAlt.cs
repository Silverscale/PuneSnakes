using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAlt : MonoBehaviour
{
    private bool[] playerStatusOnLastCheck;

    // Start is called before the first frame update
    void Start()
    {
        InitializePlayerList();
    }

    // Update is called once per frame
    void Update()
    {
        List<Player> players = Player.GetList();

        //Check for changes in player status
        for (int i = 0; i < playerStatusOnLastCheck.Length; i++) {
            if (playerStatusOnLastCheck[i] != players[i].isActive()) {
                //someone died
                GivePoints();
                playerStatusOnLastCheck[i] = players[i].isActive();
            }
        }
    }

    private void GivePoints() {
        int pointsToGive = 1;
        foreach (var player in Player.GetList()) {
            if (player.isActive()) {
                player.GivePoints(pointsToGive);
            }
        }
    }

    //Resets the list of active players, and sets everyone to true.
    private void InitializePlayerList() {
        playerStatusOnLastCheck = new bool[Player.GetList().Count];
        for (int i = 0; i < playerStatusOnLastCheck.Length; i++) {
            playerStatusOnLastCheck[i] = true;
        }
    }
}