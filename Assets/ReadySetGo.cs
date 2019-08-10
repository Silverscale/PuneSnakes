using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadySetGo : MonoBehaviour
{
    private TextMeshProUGUI text;
  
        
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
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
        Player.Go();
        Destroy(gameObject);
    }
}
