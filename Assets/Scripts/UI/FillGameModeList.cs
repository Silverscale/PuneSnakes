using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FillGameModeList : MonoBehaviour
{
    private GameModeManager manager;
    [SerializeField] private Button button = default;
    [SerializeField] private Transform folder = default;

    void Awake()
    {
        manager = FindObjectOfType<GameModeManager>();
        var modes = Resources.LoadAll<GameMode>("GameModes");
        foreach (var mode in modes) {
            CreateButton(mode);
        }
    }

    public void CreateButton(GameMode mode) {
        Button newButton = Instantiate(button, folder);
        newButton.onClick.AddListener(mode.Set);
        newButton.onClick.AddListener(manager.SetSliders);
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = mode.name;

    }
}
