using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckForEnoughPlayers : MonoBehaviour
{
    private Button startButton;

    void Start() {
        startButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        startButton.interactable = (PlayerSelector.Count >= 2) ? true : false;
    }
}
