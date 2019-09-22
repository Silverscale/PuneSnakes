using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSelector : MonoBehaviour
{
    [SerializeField] Toggle[] player = default;
    public static int Count { get; private set; } = 0;

    private void Start() {
        try {
            GameOptions.LoadPlayers();
        }
        catch (Exception) {
            Debug.LogWarning("Loading selected Players failed");
        }
        SetToggles();
    }

    private void SetToggles() {
        for (int i = 0; i < player.Length; i++) {
            player[i].isOn = GameOptions.isPlayerSelected[i];
        }
        UpdateCount();
    }

    public void SetPlayer(int playerNumber) {
        GameOptions.SetPlayer(playerNumber, player[playerNumber].isOn);
        UpdateCount();
    }

    private void UpdateCount() {
        Count = 0;
        for (int i = 0; i < player.Length; i++) {
            if (player[i].isOn) {
                Count++;
            }
        }
    }
}
