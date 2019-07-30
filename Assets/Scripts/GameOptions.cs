using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOptions : MonoBehaviour
{
    private readonly string PLAYERS_KEY = "players";
    private readonly string DELAY_KEY = "delay";
    private readonly string FRAMES_BEHIND_KEY = "framesBehind";
    private readonly string FORWARD_KEY = "forward";
    private readonly string TURNING_KEY = "turning";
    private readonly string ROUNDS_KEY = "rounds";
    private readonly string SNAKE_SIZE = "snakeScale";

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

    public void LoadOptions()
    {
        Debug.Log("***** Loading options *****");
        if (PlayerPrefs.HasKey(PLAYERS_KEY))
        {
            playerSlider.value = PlayerPrefs.GetFloat(PLAYERS_KEY);
            Debug.Log("player found with a value of " + playerSlider.value);
        }

        if (PlayerPrefs.HasKey(DELAY_KEY))
        {
            delaySlider.value = PlayerPrefs.GetFloat(DELAY_KEY);
            Debug.Log("delay found with a value of " + delaySlider.value);
        }

        if (PlayerPrefs.HasKey(FRAMES_BEHIND_KEY))
        {
            framesBehindSlider.value = (int)PlayerPrefs.GetFloat(FRAMES_BEHIND_KEY);
            Debug.Log("framesBehind found with a value of " + framesBehindSlider.value);
        }

        if (PlayerPrefs.HasKey(FORWARD_KEY))
        {
            forwardSlider.value = PlayerPrefs.GetFloat(FORWARD_KEY);
            Debug.Log("forward found with a value of " + forwardSlider.value);
        }

        if (PlayerPrefs.HasKey(TURNING_KEY))
        {
            turningSlider.value = PlayerPrefs.GetFloat(TURNING_KEY);
            Debug.Log("turning found with a value of " + turningSlider.value);
        }

        if (PlayerPrefs.HasKey(ROUNDS_KEY))
        {
            turningSlider.value = PlayerPrefs.GetFloat(ROUNDS_KEY);
            Debug.Log("rounds found with a value of " + roundsSlider.value);
        }
        if (PlayerPrefs.HasKey(SNAKE_SIZE)) {
            snakeScaleSlider.value = PlayerPrefs.GetFloat(SNAKE_SIZE);
            Debug.Log("snake scale found with a value of " + snakeScaleSlider.value);
        }
        Debug.Log("***************************");
    }

}
