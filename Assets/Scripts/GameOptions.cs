using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOptions : MonoBehaviour
{
    private static readonly string PLAYERS_KEY = "players";
    private static readonly string PLAYER1_KEY = "player1";
    private static readonly string PLAYER2_KEY = "player2";
    private static readonly string PLAYER3_KEY = "player3";
    private static readonly string PLAYER4_KEY = "player4";
    //private static readonly string DELAY_KEY = "delay";
    //private static readonly string FRAMES_BEHIND_KEY = "framesBehind";
    //private static readonly string FORWARD_KEY = "forward";
    //private static readonly string TURNING_KEY = "turning";
    private static readonly string ROUNDS_KEY = "rounds";
    //private static readonly string SNAKE_SIZE = "snakeScale";
    //private static readonly string MAX_SPEED_DELAY = "maxSpeedDelay";

    private static bool optionsLoaded = false;

    public static int maxPlayers = 4;
    public static bool[] isPlayerSelected = new bool[4];
    //public static float delay;
    //public static int framesBehind;
    //public static float forward;
    //public static float turning;
    public static int rounds;
    //public static float snakeScale;
    //public static float maxSpeedDelay;

    //public Slider maxSpeedDelaySlider;
    //public Slider delaySlider;
    //public Slider framesBehindSlider;
    //public Slider forwardSlider;
    //public Slider turningSlider;
    public Slider roundsSlider;
    //public Slider snakeScaleSlider;


    public void Start()
    {
        LoadOptions();
        SetSlidersToLoadedValue();
    }

    public static void CheckIfLoaded() {
        if (!optionsLoaded) {
            LoadOptions();
        }
    }

    private void SetSlidersToLoadedValue() {
        Debug.Log("***** Loading options *****");
        Debug.Log("***************************");
    }

    public void SetOptions() {
        maxPlayers = 4;
        rounds = (int)roundsSlider.value;
    }

    public static void SetPlayer(int playerNumber, bool selected) {
        isPlayerSelected[playerNumber] = selected;
    }



    public static void SavePlayers() {
        PlayerPrefs.SetInt(PLAYER1_KEY, boolToInt(isPlayerSelected[0]));
        PlayerPrefs.SetInt(PLAYER2_KEY, boolToInt(isPlayerSelected[1]));
        PlayerPrefs.SetInt(PLAYER3_KEY, boolToInt(isPlayerSelected[2]));
        PlayerPrefs.SetInt(PLAYER4_KEY, boolToInt(isPlayerSelected[3]));
    }
    public static void LoadPlayers() {
        isPlayerSelected[0] = intToBool(PlayerPrefs.GetInt(PLAYER1_KEY));
        isPlayerSelected[1] = intToBool(PlayerPrefs.GetInt(PLAYER2_KEY));
        isPlayerSelected[2] = intToBool(PlayerPrefs.GetInt(PLAYER3_KEY));
        isPlayerSelected[3] = intToBool(PlayerPrefs.GetInt(PLAYER4_KEY));
    }

    private static int boolToInt(bool aBool) {
        return aBool ? 1 : 0;
    }

    private static bool intToBool(int anInt) {
        return (anInt == 1) ? true : false;
    }

    public void SaveOptions()
    {
        PlayerPrefs.SetFloat(PLAYERS_KEY, 4);
        PlayerPrefs.SetFloat(ROUNDS_KEY, roundsSlider.value);

        PlayerPrefs.Save();
    }

    public static void LoadOptions()
    {
        Debug.Log("***** Loading options *****");
        if (PlayerPrefs.HasKey(PLAYERS_KEY))
        {
            maxPlayers = (int)PlayerPrefs.GetFloat(PLAYERS_KEY);
            Debug.Log("player found with a value of " + maxPlayers);
        }

        if (PlayerPrefs.HasKey(ROUNDS_KEY))
        {
            rounds = (int)PlayerPrefs.GetFloat(ROUNDS_KEY);
            Debug.Log("rounds found with a value of " + rounds);
        }
        Debug.Log("***************************");
        optionsLoaded = true;
    }
}
