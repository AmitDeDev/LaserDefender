using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float sceneLoadDelay = 2f;
    private int _currentActiveSceneIndex;

    public int GetCurrentActiveSceneIndex()
    {
        return _currentActiveSceneIndex;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        _currentActiveSceneIndex = 0;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        _currentActiveSceneIndex = 1;
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad(2, sceneLoadDelay));
        _currentActiveSceneIndex = 2;
    }

    //TODO need to create 2 more scenes for Player and Settings
    public void LoadPlayer()
    {
        SceneManager.LoadScene(3);
        _currentActiveSceneIndex = 3;
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene(4);
        _currentActiveSceneIndex = 4;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(int sceneIndex, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }
}
