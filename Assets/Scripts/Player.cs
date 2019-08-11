using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static private List<Player> playerList = new List<Player>();
    public int playerNumber { get; private set;}
 
    private Score score;
    private SnakeHead mySnake;

    public static void ClearPlayerList() {
        playerList.Clear();
    }

    public static List<Player> GetList() {
        return playerList;
    }

    public static void Go() {
        foreach (Player player in playerList) {
            player.Enable();
        }
    }



void Start()
    {
        score = GameObject.FindObjectOfType<Score>();
        Register();
        GetComponentInParent<Transform>().name = "Player " + playerNumber;
    }

    public void SetSnake(SnakeHead newSnake) {
        mySnake = newSnake;
    }

    public void PlayerDied() {
        score.PlayerKill(this);
    }

    private void Register() {
        playerList.Add(this);
        playerNumber = playerList.Count - 1;
    }

    public void Disable() {
        mySnake.enabled = false;
        mySnake.GetComponent<SnakeMovement>().Stop();
    }

    public void Enable() {
        mySnake.enabled = true;
        mySnake.GetComponent<SnakeMovement>().Resume();
    }

}
