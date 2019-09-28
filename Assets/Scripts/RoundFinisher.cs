using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundFinisher : MonoBehaviour
{
    private Loader loader; 
    private bool finishing = false;

    void Start()
    {
        loader = FindObjectOfType<Loader>();
    }

    void Update()
    {
        if (Player.LeftActive() <= 1 && !finishing) {
            finishing = true;
            StartCoroutine(PlayerWon());
        }
    }

    private IEnumerator PlayerWon() {
        //Stop all snakes
        for (int i = 0; i < 35; i++) {
            Time.timeScale -= 0.02f;
            yield return new WaitForFixedUpdate();
        }
        foreach (var snake in FindObjectsOfType<SnakeHead>()) {
            if (snake.IsAlive) {
                snake.Wait();
            }
        }
        Time.timeScale = 1;

        print("Someone won!");
        yield return new WaitForSeconds(2f);
        print("Press any key.");
        yield return new WaitUntil(AnyKeyPress);

        FinishRound();
        /*foreach (var snake in FindObjectsOfType<SnakeHead>()) {
            if (snake.IsAlive) {
                snake.GetComponent<SnakeMovement>().DecelerateAndStop();
            }
        }*/
        //Stop scoring
        //show a "Player won" sign
        //do Finish Round after key press.
    }

    private bool AnyKeyPress() {
        return Input.anyKey;
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

    //Called from the "Menu" button, in the Game scene
    public void BackToMenu() {
        ClearBoard();
        loader.LoadScene(1);
    }
}
