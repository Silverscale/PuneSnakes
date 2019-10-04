using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FillGameModeList : MonoBehaviour
{
    [SerializeField] private Button button = default;
    [SerializeField] private Transform folder = default;

    void Awake()
    {
        var modes = Resources.LoadAll<GameMode>("GameModes");
        foreach (var mode in modes) {
            Button newButton = Instantiate(button, folder);
            newButton.onClick.AddListener(mode.Set);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = mode.name;
        }
    }
}
