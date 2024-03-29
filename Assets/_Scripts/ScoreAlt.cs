﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAlt : MonoBehaviour
{
    private bool[] wasPlayerAliveOnLastCheck;

    // Start is called before the first frame update
    void Start()
    {
        InitializePlayerCheckList();
    }

    //Resets the list of active players, and sets everyone to true(alive).
    private void InitializePlayerCheckList() {
        wasPlayerAliveOnLastCheck = new bool[Player.GetFullList().Count];
        for (int i = 0; i < wasPlayerAliveOnLastCheck.Length; i++) {
            wasPlayerAliveOnLastCheck[i] = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        List<Player> players = Player.GetFullList();

        //Check for changes in player status
        for (int i = 0; i < wasPlayerAliveOnLastCheck.Length; i++) {
            if (wasPlayerAliveOnLastCheck[i] != players[i].IsActive()) {
                //someone died
                GivePoints();
                wasPlayerAliveOnLastCheck[i] = players[i].IsActive();
            }
        }
    }

    private void GivePoints() {
        int pointsToGive = 1;
        foreach (var player in Player.GetFullList()) {
            if (player.IsActive()) {
                player.RecievePoints(pointsToGive);
            }
        }
    }
}