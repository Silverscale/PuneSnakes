using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    static public Loader instance;
    [SerializeField] private float delayAtSplash = 3f;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
            return;
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
