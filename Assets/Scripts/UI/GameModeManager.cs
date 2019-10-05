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
    }

    void Update()
    {
        Debug.Log("Text: " + nameField.text);
        Debug.Log("Comparison: " + (nameField.text != "").ToString());
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

        AssetDatabase.CreateAsset(newMode, "Assets/Resources/GameModes/" + newMode.name + ".asset");
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
}
