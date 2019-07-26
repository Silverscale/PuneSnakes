using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOptions : MonoBehaviour
{
    public static int players;
    public static float delay;
    public static int framesBehind;
    public static float forward;
    public static float turning;
    

    public Slider playerSlider;
    public Slider delaySlider;
    public Slider framesBehindSlider;
    public Slider forwardSlider;
    public Slider turningSlider;


    public void Start()
    {
        LoadOptions();
    }
    public void SetPlayers() {
        players = (int)playerSlider.value;
    }

    public void SetDelay() {
        delay = delaySlider.value;
    }

    public void SetFramesBehind() {
        framesBehind = (int)framesBehindSlider.value;
    }

    public void SetForward() {
        forward = forwardSlider.value;
    }

    public void SetTurning() {
        turning = turningSlider.value;
    }

    public void SetOptions() {
        SetPlayers();
        SetDelay();
        SetFramesBehind();
        SetForward();
        SetTurning();
    }

    /*On macOS PlayerPrefs are stored in ~/Library/Preferences folder, 
     * in a file named unity.[company name].[product name].plist, where company and product names are the names set up in Project Settings.
     * The same .plist file is used for both Projects run in the Editor and standalone players.
         On Windows, PlayerPrefs are stored in the registry under HKCU\Software\[company name]\[product name] key,
         where company and product names are the names set up in Project Settings.*/

    public void SaveOptions()
    {
        PlayerPrefs.SetFloat("player", playerSlider.value);
        PlayerPrefs.SetFloat("delay", delaySlider.value);
        PlayerPrefs.SetFloat("framesBehind", framesBehindSlider.value);
        PlayerPrefs.SetFloat("forward", forwardSlider.value);
        PlayerPrefs.SetFloat("turning", turningSlider.value);

        PlayerPrefs.Save();
        

    }

    public void LoadOptions()
    {
        if (PlayerPrefs.HasKey("player"))
        {
            playerSlider.value = PlayerPrefs.GetFloat("player");
        }

        if (PlayerPrefs.HasKey("delay"))
        {
            delaySlider.value = PlayerPrefs.GetFloat("delay");
        }

        if (PlayerPrefs.HasKey("framesBehind"))
        {
            framesBehindSlider.value = (int)PlayerPrefs.GetFloat("player");
        }

        if (PlayerPrefs.HasKey("forward"))
        {
            playerSlider.value = PlayerPrefs.GetFloat("player");
        }

        if (PlayerPrefs.HasKey("turning"))
        {
            playerSlider.value = PlayerPrefs.GetFloat("turning");
        }

        


    }

}
