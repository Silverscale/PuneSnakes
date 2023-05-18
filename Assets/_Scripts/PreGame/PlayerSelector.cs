using System;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField] private AvatarCustomizator[] players;
    [SerializeField] private GameObject playerPrefab = default;

    public static int Count { get; private set; } = 0;

    public delegate void CountUpdateEventHandler(int newCount);
    public static event CountUpdateEventHandler OnCountChanged;

    private void Awake() {
        foreach (var playerCustomizator in players) {
            playerCustomizator.OnPlayerSelectionChanged += ChangeCount;
        }        
    }

    private void ChangeCount(int playerId, bool selectionState) {
        int count = 0;
        foreach (var playerCustomizator in players) {
            if (playerCustomizator.IsPlayerSelected()) {
                count++;
            }
        }
        Count = count;
        OnCountChanged?.Invoke(Count);
    }
    
    public PlayerCustomizationChoices[] PollPlayerChoices() {
        var result = new PlayerCustomizationChoices[Count];
        int i = 0;
        foreach (var player in players) {

            if (player.IsPlayerSelected()) {
                result[i++] = player.GetPlayerChoices();
            }
        }
        return result;
    }


    public void CreatePlayers() {
        PlayerCustomizationChoices[] playerChoices = PollPlayerChoices();
        Player.CreateNewPlayers(playerChoices, playerPrefab);
    }

    private void OnDestroy() {
        foreach (var playerCustomizator in players) {
            playerCustomizator.OnPlayerSelectionChanged -= ChangeCount;
        }
        Count = 0;
    }

}
