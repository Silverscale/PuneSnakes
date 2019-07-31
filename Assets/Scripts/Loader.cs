using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [SerializeField] private float delayAtSplash = 3f;

    public void MainMenu(float delay)
    {
        Debug.Log("Start Main Menu");
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
