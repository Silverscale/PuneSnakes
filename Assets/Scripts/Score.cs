using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour

{
    private Setup currentSetup;
    private List<Player> alivePlayers;
    private List<Player> allPlayers;
    private int[] scoreboard;
    public string scoreDisplay;
    private GameObject scoreboardDisplay;
    private int rounds;
    //public GameOptions currentOptions;


    private Loader loader;


    static Score instance;

    // Start is called before the first frame update
    void Start()
    {
        currentSetup = FindObjectOfType<Setup>();

        loader = FindObjectOfType<Loader>();

        rounds = GameOptions.rounds;

        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this.gameObject);


        DontDestroyOnLoad(this);
        scoreboard = new int[4]; //Expandir
        allPlayers = currentSetup.playerList;
        alivePlayers = new List<Player>(allPlayers);
            
    }

    // Update is called once per frame
    void Update()
    {

        scoreDisplay =
            "Player 1: " + scoreboard[0] + " " +
            "Player 2: " + scoreboard[1] + " " +
            "Player 3: " + scoreboard[2] + " " +
            "Player 4: " + scoreboard[3];

        //scoreboardDisplay.GetComponent<Text>().text = scoreDisplay;
    }

    public void playerKill(Player deadPlayer)
    {
        alivePlayers.Remove(deadPlayer);
        givePoints();

        if (alivePlayers.Count == 0)
        {
            finishRound();
        }
    }

    private void givePoints()
    {
        foreach (Player p in alivePlayers)
        {
            scoreboard[p.playerNumber]++;
        }
        Debug.Log("Point given");
    }

    private void finishRound()
    {
        rounds--;

        if (rounds!=0)
        {
            Debug.Log("Round finished: Rounds left: " + rounds);
            startRound();
        }
    }

    private void startRound()
    {
        
        loader.Game();

        currentSetup = FindObjectOfType<Setup>();
        alivePlayers = new List<Player>(currentSetup.playerList);
        Debug.Log("Alive Players: " + alivePlayers.Count + "All players: " + allPlayers.Count);
    }

    
}
