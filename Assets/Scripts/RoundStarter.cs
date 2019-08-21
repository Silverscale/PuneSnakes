using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStarter : MonoBehaviour
{
    private SnakeHead[] playerSnakes;
    [SerializeField] float countdownDuration = default;

    // Start is called before the first frame update
    void Start()
    {
        playerSnakes = FindObjectsOfType<SnakeHead>();
        StartCoroutine(StartRoundAfterSeconds(countdownDuration));
    }

    //Calls StartRound() after countdownDuration seconds
    private IEnumerator StartRoundAfterSeconds(float seconds) {
        yield return new WaitForSeconds(seconds);
        StartRound();
    }
    public void StartRound() {
        foreach (var snake in playerSnakes) {
            snake.Go();
        }
    }
}
