using System;
using UnityEngine;
using UnityEngine.UI;

public class AvatarCustomizator : MonoBehaviour
{
    [SerializeField] private int playerIdNumber;

    private PlayerCustomizationChoices choices;

    private IPlayerNamePicker playerNamePicker;
    private ISnakeBodyPicker bodyPicker;
    private ISnakeColorPicker colorPicker;
    private Toggle panelToggle;

    public delegate void PlayerSelectionEventHandler(int playerIdNumber, bool newSelectionState);
    public event PlayerSelectionEventHandler OnPlayerSelectionChanged;

    private void Awake() {
        playerNamePicker = GetComponent<IPlayerNamePicker>();
        bodyPicker = GetComponent<ISnakeBodyPicker>();
        colorPicker = GetComponent<ISnakeColorPicker>();
        panelToggle = GetComponentInChildren<Toggle>();

        Setup(playerIdNumber);
        StartListeningToToggle();
    }

    private void StartListeningToToggle() {
        panelToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    private void OnToggleChanged(bool toggleNewState) {
        OnPlayerSelectionChanged?.Invoke(playerIdNumber, toggleNewState);
    }

    public void Setup(int playerIdNumber) {
        this.playerIdNumber = playerIdNumber;
        playerNamePicker.DefaultName(playerIdNumber);
        panelToggle.GetComponentInChildren<Text>().text = "Player " + (playerIdNumber + 1).ToString();
    }

    public PlayerCustomizationChoices GetPlayerChoices() {
        choices = new PlayerCustomizationChoices(
            playerIdNumber,
            playerNamePicker.GetPlayerName(),
            bodyPicker.GetSelectedAvatarType(),
            colorPicker.GetSelectedSnakeColor());
 
        return choices; 
    }

    public bool IsPlayerSelected() {
        return panelToggle.isOn;
    }


}
