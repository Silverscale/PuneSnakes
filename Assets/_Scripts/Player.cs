using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static private List<Player> playerList = new List<Player>();

    public int idNumber { get; private set; }
    public Color color { get; private set; } //out

    public PlayerCustomizationChoices choices { get; private set; }

    private bool active = true;
    private bool wasNumberSet = false; //pointless?

    public int Score { get; private set; } = 0;


    public static void CreateNewPlayers(PlayerCustomizationChoices[] playerChoices, GameObject playerPrefab) {
        ClearPlayerList();

        //foreach (var selectedPlayer in playerChoices) {
        //    Player newPlayer = Object.Instantiate<GameObject>(playerPrefab.gameObject).GetComponent<Player>();
        //    newPlayer.SetChoices(selectedPlayer);
        //    DontDestroyOnLoad(newPlayer.gameObject);

        //}
        for (int i = 0; i < playerChoices.Length; i++) {
            //Create the players for the match
            Player newPlayer = Object.Instantiate<GameObject>(playerPrefab.gameObject).GetComponent<Player>();
            newPlayer.SetChoices(playerChoices[i]);
            DontDestroyOnLoad(newPlayer.gameObject);
        }
    }


     public static void ClearPlayerList() {
        for (int i = 0; i < playerList.Count; i++) {
            Destroy(playerList[i].gameObject);
        }
        playerList.Clear();
    }

    public static List<Player> GetFullList() {
        return playerList;
    }

    public static Player GetPlayer(int index) {
        return playerList[index];
    }
    public static int LeftActive() {
        int playersLeft = 0;
        foreach (var player in playerList) {
            if (player.IsActive()) {
                playersLeft++;
            }
        }
        return playersLeft;
    }


    void Awake()
    {
        Register();
        color = Random.ColorHSV();
        transform.name = "Player " + idNumber;
        DontDestroyOnLoad(gameObject);
    }

    //Agrega el Player que acaba de ser creado a la playerList, y toma de ahi el playerNumber
    private void Register() {
        playerList.Add(this);
        if (!wasNumberSet) {
            SetNumber(playerList.Count - 1);
        }
    }

    public void SetNumber(int number) {
        idNumber = number;
        wasNumberSet = true;
    }

    public void SetChoices(PlayerCustomizationChoices choices) => this.choices = choices;
    public void SetAsInactive() => active = false;

    public void SetAsActive() => active = true;

    public bool IsActive() => active;
    public void RecievePoints(int points) => Score += points;
}
