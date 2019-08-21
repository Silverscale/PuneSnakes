using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreBoard : MonoBehaviour
{
    private TextMeshProUGUI scoreTMP;
    private int[] previousScores;
    void Start()
    {
        previousScores = new int[GameOptions.players];
        scoreTMP = GetComponent<TextMeshProUGUI>();
        UpdateScoreString();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckForScoreChanges()) {
            UpdateScoreString();
        }
    }

    private bool CheckForScoreChanges() {
        bool scoreChanged = false;
        for (int i = 0; i < GameOptions.players; i++) {
            int actualScore = Player.GetPlayer(i).Score;
            if (actualScore != previousScores[i]) {
                scoreChanged = true;
                previousScores[i] = actualScore;
            }
        }
        return scoreChanged;
    }

    private void UpdateScoreString() {
        string scoreString = "";
        foreach (var player in Player.GetList()) {
            scoreString += "Player " + player.playerNumber +": " + player.Score + "\n";
        };
        scoreTMP.text = scoreString;
    }
}
