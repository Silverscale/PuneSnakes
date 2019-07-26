using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour

{
    public Setup currentSetup;
    private List<Player> alivePlayers;
    private int[] scoreboard;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        scoreboard = new int[4]; //Expandir
        alivePlayers = currentSetup.playerList;
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void playerKill(Player deadPlayer)
    {
        alivePlayers.Remove(deadPlayer);
        givePoints();
    }

    private void givePoints()
    {
        foreach (Player p in alivePlayers)
        {
            scoreboard[p.playerNumber]++;
        }


        
    }
}
