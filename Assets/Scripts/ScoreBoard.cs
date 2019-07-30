using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    // Start is called before the first frame update
    private Score currentScore;
    private Text scoreText;

    void Start()
    {
        currentScore = FindObjectOfType<Score>();
        //scoreText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = currentScore.scoreDisplay;
    }
}
