using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Audio players components.
    private AudioLibrary audioLibrary;
    [SerializeField] private AudioSource EffectsSource = default;
    [SerializeField] private AudioSource MusicSource = default;

    // Random pitch adjustment range.
    [SerializeField] private float LowPitchRange = .95f;
    [SerializeField] private float HighPitchRange = 1.05f;

    // Singleton instance.
    public static SoundManager Instance;

    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
            //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
            DontDestroyOnLoad(gameObject);
            audioLibrary = GetComponent<AudioLibrary>();
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayReadySetGo() {
        PlaySFX(audioLibrary.GetReadySetGoSFX());
    }
    public void PlayGameMusic() {
        PlayMusic(audioLibrary.GetGameMusic());
    }
    public void PlayMenuMusic() {
        PlayMusic(audioLibrary.GetMenuMusic());
    }
    public void PlayDeathSFX() {
        PlaySFX(audioLibrary.GetDeathSFX());
    }
    
    // Play a single clip through the sound effects source.
    private void PlaySFX(AudioClip clip)
    {
        EffectsSource.clip = clip;
        EffectsSource.Play();
    }

    // Play a single clip through the music source.
    private void PlayMusic(AudioClip clip) {
        MusicSource.clip = clip;
        MusicSource.Play();
    }


    // Play a random clip from an array, and randomize the pitch slightly.
    public void RandomSoundEffect(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

        EffectsSource.pitch = randomPitch;
        EffectsSource.clip = clips[randomIndex];
        EffectsSource.Play();
    }
}
