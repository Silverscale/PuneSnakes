using UnityEngine;

public class UINamePicker : MonoBehaviour, IPlayerNamePicker
{
    [SerializeField] TMPro.TMP_InputField nameField;

    public void DefaultName(int playerId) {
        nameField.text = "Player " + (playerId + 1).ToString();
    }

    public string GetPlayerName() {
        return nameField.text;
    }
}
