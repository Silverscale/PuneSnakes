using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLibrary : MonoBehaviour
{
    [SerializeField] private AudioClip menuMusic = default;
    [SerializeField] private AudioClip gameMusic = default;
    [SerializeField] private AudioClip deathSFX = default;
    [SerializeField] private AudioClip readySetGoSFX = default;

    public AudioClip GetMenuMusic() {
        return menuMusic;
    }
    public AudioClip GetGameMusic() {
        return gameMusic;
    }
    public AudioClip GetDeathSFX() {
        return deathSFX;
    }
    public AudioClip GetReadySetGoSFX() {
        return readySetGoSFX;
    }
}
