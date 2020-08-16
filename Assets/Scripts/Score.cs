using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour

{
    private RoundSetup currentSetup;
    private List<Player> alivePlayers;
    private List<Player> allPlayers;
    private int[] scoreboard;
    public string scoreDisplay;
    private GameObject scoreboardDisplay;
    private int rounds;

    private AudioClip deathClip;
    //public GameOptions currentOptions;


    private Loader loader;


    static Score instance;

    // Start is called before the first frame update
    void Start()
    {
        
        deathClip = (AudioClip)Resources.Load("Sounds/Death");
        

        currentSetup = FindObjectOfType<RoundSetup>();

        loader = FindObjectOfType<Loader>();

        rounds = GameOptions.rounds;

        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this.gameObject);


        DontDestroyOnLoad(this);
        scoreboard = new int[4]; //Expandir
        allPlayers = Player.GetList();
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

    public void PlayerKill(Player deadPlayer)
    {

        alivePlayers.Remove(deadPlayer);
        GivePoints();

        if (alivePlayers.Count == 0)
        {
            FinishRound();
        }

        //else
        //{
        //    SoundManager.Instance.PlayDeathSFX();
        //}
    }

    private void GivePoints()
    {
        foreach (Player p in alivePlayers)
        {
            scoreboard[p.idNumber]++;
        }
        Debug.Log("Point given");
    }

    private void FinishRound()
    {
        rounds--;

        if (rounds!=0)
        {
            Debug.Log("Round finished: Rounds left: " + rounds);
            StartRound();
        }
    }

    private void StartRound()
    {
        
        loader.Game();

        currentSetup = FindObjectOfType<RoundSetup>();
        alivePlayers = new List<Player>(Player.GetList());
        Debug.Log("Alive Players: " + alivePlayers.Count + "All players: " + allPlayers.Count);
    }

    
}
