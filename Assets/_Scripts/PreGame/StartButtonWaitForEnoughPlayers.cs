using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartButtonWaitForEnoughPlayers : MonoBehaviour
{
    private Button startButton;

    private void Awake() {
        startButton = GetComponent<Button>();
        PlayerSelector.OnCountChanged += CheckForEnoughPlayers;
    }

    private void CheckForEnoughPlayers(int playerCount)
    {
        int playersRequired = 2;
        if (playerCount >= playersRequired) {
            startButton.interactable = true;
        } else {
            startButton.interactable = false;
        }
    }

    private void OnDestroy() {
        PlayerSelector.OnCountChanged -= CheckForEnoughPlayers;
    }
}
