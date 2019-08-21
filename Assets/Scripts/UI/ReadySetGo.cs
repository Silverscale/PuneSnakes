using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadySetGo : MonoBehaviour
{
    private TextMeshProUGUI text = default;
  
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        SoundManager.Instance.PlayReadySetGo();
        text.text = "Ready!";
    }

    //All these are called from the animator in the ReadySetGo gameObject
    public void Set() {
        text.text = "Set!";
    }

    public void Go() {
        text.text = "Go!";
    }

    public void StartRound() {
        text.gameObject.SetActive(false);
    }
}
