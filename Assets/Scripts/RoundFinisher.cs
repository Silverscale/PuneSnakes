using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundFinisher : MonoBehaviour
{
    private Loader loader; 

    void Start()
    {
        loader = FindObjectOfType<Loader>();
    }

    void Update()
    {
        if (Player.LeftActive() <= 1) {
            FinishRound();
        }
    }

    private void FinishRound() {
        ClearBoard();
        LoadPostGame();
    }

    private void ClearBoard() {
        foreach (var snake in FindObjectsOfType<SnakeHead>()) {
            snake.SelfDestruct();
        }
    }
    private void LoadPostGame() {
        loader.LoadScene(6);
    }

    //Called from "Finish" button, in the Game scene
    public void ForceRoundEnd() {
        FinishRound();
    }
}
