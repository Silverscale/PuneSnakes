using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static private List<Player> playerList = new List<Player>();
    public int playerNumber { get; private set;}
    private bool active = true;
    //private Score score;
    private SnakeHead mySnake;
    private int score = 0;

    //Prepara la lista para una nueva partida
    public static void ClearPlayerList() {
        for (int i = 0; i < playerList.Count; i++) {
            Destroy(playerList[0].gameObject);
        }
        playerList.Clear();
    }

    //Devuelve la lista completa de jugadores
    public static List<Player> GetList() {
        return playerList;
    }

    public static Player GetPlayer(int index) {
        Debug.Log("Getting player " + index + ". Total players registered: " + playerList.Count);
        return playerList[index];
    }

    //Arranca la ronda. Posiblemente no deba estar en esta clase.
    //Es lo que causa la referencia ciclica
    public static void Go() {
        foreach (Player player in playerList) {
            player.Enable();
        }
    }



void Start()
    {
        //score = GameObject.FindObjectOfType<Score>();
        Register();
        transform.name = "Player " + playerNumber;
        DontDestroyOnLoad(gameObject);
    }

    public void SetSnake(SnakeHead newSnake) {
        mySnake = newSnake;
    }

    public void PlayerDied() {
        //score.PlayerKill(this);
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

    public void Enable() {
        mySnake.enabled = true;
        mySnake.GetComponent<SnakeMovement>().Resume();
        active = true;
    }

    public bool isActive() {
        return active;
    }
    public void GivePoints(int points) {
        score += points;
    }
}
