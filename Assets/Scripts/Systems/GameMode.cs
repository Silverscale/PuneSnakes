using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Game Mode")]
public class GameMode : ScriptableObject
{
    public static float BODY_EXPAND_DELAY;
    public static int BODY_FRAMES_BEHIND;
    public static float MAX_FORWARD_SPEED;
    public static float TURNING_RATE;
    public static float SNAKE_SCALE;
    public static float DELAY_UNTIL_MAXSPEED;
    public static bool DRUNK_DRAGONS;

    public float delay;
    public int framesBehind;
    public float forward;
    public float turning;
    public float snakeScale;
    public float maxSpeedDelay;
    public bool drunkDragons;

    public void Set() {
        BODY_EXPAND_DELAY = delay;
        BODY_FRAMES_BEHIND = framesBehind;
        MAX_FORWARD_SPEED = forward;
        TURNING_RATE = turning;
        SNAKE_SCALE = snakeScale;
        DELAY_UNTIL_MAXSPEED = maxSpeedDelay;
        DRUNK_DRAGONS = drunkDragons;
        Debug.Log("Game Mode changed to: " + this.name);
    }
}
