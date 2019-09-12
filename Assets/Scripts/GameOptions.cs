using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOptions : MonoBehaviour
{
    private static readonly string PLAYERS_KEY = "players";
    private static readonly string DELAY_KEY = "delay";
    private static readonly string FRAMES_BEHIND_KEY = "framesBehind";
    private static readonly string FORWARD_KEY = "forward";
    private static readonly string TURNING_KEY = "turning";
    private static readonly string ROUNDS_KEY = "rounds";
    private static readonly string SNAKE_SIZE = "snakeScale";

    private static bool optionsLoaded = false;

    public static int players;
    public static float delay;
    public static int framesBehind;
    public static float forward;
    public static float turning;
    public static int rounds;
    public static float snakeScale;


    public Slider playerSlider;
    public Slider delaySlider;
    public Slider framesBehindSlider;
    public Slider forwardSlider;
    public Slider turningSlider;
    public Slider roundsSlider;
    public Slider snakeScaleSlider;


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
        if (PlayerPrefs.HasKey(PLAYERS_KEY))
        {
            playerSlider.value = players;
        }

        if (PlayerPrefs.HasKey(DELAY_KEY))
        {
            delaySlider.value = delay;
        }

        if (PlayerPrefs.HasKey(FRAMES_BEHIND_KEY))
        {
            framesBehindSlider.value = framesBehind;
        }

        if (PlayerPrefs.HasKey(FORWARD_KEY))
        {
            forwardSlider.value = forward;
        }

        if (PlayerPrefs.HasKey(TURNING_KEY))
        {
            turningSlider.value = turning;
        }

        if (PlayerPrefs.HasKey(ROUNDS_KEY))
        {
            roundsSlider.value = rounds;
        }
        if (PlayerPrefs.HasKey(SNAKE_SIZE)) {
            snakeScaleSlider.value = snakeScale;
        }
        Debug.Log("***************************");
    }

    public void SetOptions() {
        players = (int)playerSlider.value;
        delay = delaySlider.value;
        framesBehind = (int)framesBehindSlider.value;
        forward = forwardSlider.value;
        turning = turningSlider.value;
        rounds = (int)roundsSlider.value;
        snakeScale = snakeScaleSlider.value;
    }

    /*On macOS PlayerPrefs are stored in ~/Library/Preferences folder, 
     * in a file named unity.[company name].[product name].plist, where company and product names are the names set up in Project Settings.
     * The same .plist file is used for both Projects run in the Editor and standalone players.
         On Windows, PlayerPrefs are stored in the registry under HKCU\Software\[company name]\[product name] key,
         where company and product names are the names set up in Project Settings.*/

    public void SaveOptions()
    {
        PlayerPrefs.SetFloat(PLAYERS_KEY, playerSlider.value);
        PlayerPrefs.SetFloat(DELAY_KEY, delaySlider.value);
        PlayerPrefs.SetFloat(FRAMES_BEHIND_KEY, framesBehindSlider.value);
        PlayerPrefs.SetFloat(FORWARD_KEY, forwardSlider.value);
        PlayerPrefs.SetFloat(TURNING_KEY, turningSlider.value);
        PlayerPrefs.SetFloat(ROUNDS_KEY, roundsSlider.value);
        PlayerPrefs.SetFloat(SNAKE_SIZE, snakeScaleSlider.value);

        /*Debug.Log("***** Saving options *****");
        Debug.Log("player: " + playerSlider.value);
        Debug.Log("delay: " + delaySlider.value);
        Debug.Log("framesBehind: " + framesBehindSlider.value);
        Debug.Log("forward: " + forwardSlider.value);
        Debug.Log("turning: " + turningSlider.value);
        Debug.Log("rounds: " + roundsSlider.value);
        Debug.Log("***************************");
        */
        PlayerPrefs.Save();
    }

    public static void LoadOptions()
    {
        Debug.Log("***** Loading options *****");
        if (PlayerPrefs.HasKey(PLAYERS_KEY))
        {
            players = (int)PlayerPrefs.GetFloat(PLAYERS_KEY);
            Debug.Log("player found with a value of " + players);
        }

        if (PlayerPrefs.HasKey(DELAY_KEY))
        {
            delay = PlayerPrefs.GetFloat(DELAY_KEY);
            Debug.Log("delay found with a value of " + delay);
        }

        if (PlayerPrefs.HasKey(FRAMES_BEHIND_KEY))
        {
            framesBehind = (int)PlayerPrefs.GetFloat(FRAMES_BEHIND_KEY);
            Debug.Log("framesBehind found with a value of " + framesBehind);
        }

        if (PlayerPrefs.HasKey(FORWARD_KEY))
        {
            forward = PlayerPrefs.GetFloat(FORWARD_KEY);
            Debug.Log("forward found with a value of " + forward);
        }

        if (PlayerPrefs.HasKey(TURNING_KEY))
        {
            turning = PlayerPrefs.GetFloat(TURNING_KEY);
            Debug.Log("turning found with a value of " + turning);
        }

        if (PlayerPrefs.HasKey(ROUNDS_KEY))
        {
            rounds = (int)PlayerPrefs.GetFloat(ROUNDS_KEY);
            Debug.Log("rounds found with a value of " + rounds);
        }
        if (PlayerPrefs.HasKey(SNAKE_SIZE)) {
            snakeScale = PlayerPrefs.GetFloat(SNAKE_SIZE);
            Debug.Log("snake scale found with a value of " + snakeScale);
        }
        Debug.Log("***************************");
        optionsLoaded = true;
    }
}
