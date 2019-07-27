using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadySetGo : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private Setup setup;
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void Ready() {
        text.text = "Ready!";
    }

    public void Set() {
        text.text = "Set!";
    }

    public void Go() {
        text.text = "Go!";
    }

    public void StartRound() {
        setup.StartRound();
        Destroy(gameObject);
    }
}
