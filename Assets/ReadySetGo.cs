using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadySetGo : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private Setup setup;

    private AudioClip readyClip;
 
        
        // Start is called before the first frame update
        void Awake()
    {
            readyClip = (AudioClip)Resources.Load("Sounds/ReadySaori");
            text = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        SoundManager.Instance.Play(readyClip);
    }

    public void Ready() {

        text.text = "Ready!";

        Debug.Log("READY!!");
        
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
