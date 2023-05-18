using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameModeSelector : MonoBehaviour, IGameModePicker
{

    [SerializeField] private TMP_Dropdown dropDown;
    [SerializeField] private TMP_Text descriptionTextDisplay;

    private List<GameMode> gameModes;
    private GameMode currentMode;

    private void Awake() {
        dropDown = GetComponentInChildren<TMP_Dropdown>();
        descriptionTextDisplay = GetComponentInChildren<TMP_Text>();

        var gameModesArray = Resources.LoadAll<GameMode>("GameModes");
        if (gameModesArray.Length == 0) {
            Debug.LogError("No game modes found in Resources/GameModes folder.");
            return;
        }
        gameModes = new List<GameMode>(gameModesArray);
    }


    void Start()
    {
        PopulateDropdown();
        StartListeningToDropdownSelection();
    }

    private void PopulateDropdown() {
        dropDown.ClearOptions();

        var gameModeNames = new List<string>();
        foreach (var gm in gameModes) {
            gameModeNames.Add(gm.modeName);
        }
        
        dropDown.AddOptions(gameModeNames);
        ModeSelected(0);
    }
    private void ModeSelected(int index) {
        currentMode = gameModes[index];
        descriptionTextDisplay.text = currentMode.description;
    }

    private void StartListeningToDropdownSelection() {
        dropDown.onValueChanged.AddListener(ModeSelected);
    }

    public GameMode GetSelectedGameMode() {
        return currentMode;
    }
}
