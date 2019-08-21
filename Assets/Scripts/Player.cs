using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static private List<Player> playerList = new List<Player>();
    public int playerNumber { get; private set;}
    private bool active = true;
    private SnakeHead mySnake;
    private int score = 0;
    public int Score { get { return score; } }

    //Prepara la lista para una nueva partida
    public static void ClearPlayerList() {
        for (int i = 0; i < playerList.Count; i++) {
            Destroy(playerList[i].gameObject);
        }
        playerList.Clear();
    }

    //Devuelve la lista completa de jugadores
    public static List<Player> GetList() {
        return playerList;
    }

    public static Player GetPlayer(int index) {
        return playerList[index];
    }
    public static int LeftActive() {
        int playersLeft = 0;
        foreach (var player in playerList) {
            if (player.isActive()) {
                playersLeft++;
            }
        }
        return playersLeft;
    }

    void Start()
    {
        Register();
        transform.name = "Player " + playerNumber;
        DontDestroyOnLoad(gameObject);
    }

    public void SetSnake(SnakeHead newSnake) {
        mySnake = newSnake;
    }

    //Agrega el Player que acaba de ser creado a la playerList, y toma de ahi el playerNumber
    private void Register() {
        playerList.Add(this);
        playerNumber = playerList.Count - 1;
    }

    public void Disable() {
        mySnake.enabled = false;
        mySnake.GetComponent<SnakeMovement>().Stop();
        active = false;
    }

    public void SetAsActive() {
        active = true;
    }

    public bool isActive() {
        return active;
    }
    public void RecievePoints(int points) {
        score += points;
    }
}
