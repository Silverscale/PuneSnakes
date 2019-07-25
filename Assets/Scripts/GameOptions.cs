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
}
