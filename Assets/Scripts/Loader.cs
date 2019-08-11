﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [SerializeField] private float delayAtSplash = 3f;

    private void Start() {
        //Check if this is the Splash screen, and load the main menu after delayAtSplash seconds.
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            MainMenu(delayAtSplash);
        }
    }

    public void MainMenu(float delay)
    {
        StartCoroutine(LoadScene(0, delay));
    }

    public void Game() {
        StartCoroutine(LoadScene(1, 0.5f));
    }

    private IEnumerator LoadScene(int sceneIndex, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneIndex);
    }
}