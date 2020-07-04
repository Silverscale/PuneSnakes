using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class GameModeManager : MonoBehaviour
{
    private FillGameModeList gameModeList;

    public TMP_InputField nameField;
    public Button saveButton;

    public Slider maxSpeedDelaySlider;
    public Slider delaySlider;
    public Slider framesBehindSlider;
    public Slider forwardSlider;
    public Slider turningSlider;
    public Slider snakeScaleSlider;
    public Toggle drunkDragonsToggle;

    void Awake() {
        gameModeList = FindObjectOfType<FillGameModeList>();
        SetSliders();
    }

    void Update()
    {
        bool enableButton = (nameField.text != "");
        saveButton.interactable = enableButton;
    }

    public void Create() {
        var newMode = ScriptableObject.CreateInstance<GameMode>();

        newMode.name = nameField.text;
        newMode.delay = delaySlider.value;
        newMode.framesBehind = (int)framesBehindSlider.value;
        newMode.forward = forwardSlider.value;
        newMode.turning = turningSlider.value;
        newMode.snakeScale = snakeScaleSlider.value;
        newMode.maxSpeedDelay = maxSpeedDelaySlider.value;
        newMode.drunkDragons = drunkDragonsToggle.isOn;

#if UNITY_EDITOR
        AssetDatabase.CreateAsset(newMode, "Assets/Resources/GameModes/" + newMode.name + ".asset");
        //some code here that uses something from the UnityEditor namespace
# endif
        gameModeList.CreateButton(newMode);
    }

    public void SetSliders() {
        maxSpeedDelaySlider.value = GameMode.DELAY_UNTIL_MAXSPEED;
        delaySlider.value = GameMode.BODY_EXPAND_DELAY;
        framesBehindSlider.value = GameMode.BODY_FRAMES_BEHIND;
        forwardSlider.value = GameMode.MAX_FORWARD_SPEED;
        turningSlider.value = GameMode.TURNING_RATE;
        snakeScaleSlider.value = GameMode.SNAKE_SCALE;
        drunkDragonsToggle.isOn = GameMode.DRUNK_DRAGONS;
    }

    public void SetParametersFromSliders() {
        GameMode.BODY_EXPAND_DELAY = delaySlider.value;
        GameMode.BODY_FRAMES_BEHIND = (int)framesBehindSlider.value;
        GameMode.MAX_FORWARD_SPEED = forwardSlider.value;
        GameMode.TURNING_RATE = turningSlider.value;
        GameMode.SNAKE_SCALE = snakeScaleSlider.value;
        GameMode.DELAY_UNTIL_MAXSPEED = maxSpeedDelaySlider.value;
        GameMode.DRUNK_DRAGONS = drunkDragonsToggle.isOn;
        Debug.Log("Game Mode set from slider values");
    }
}
