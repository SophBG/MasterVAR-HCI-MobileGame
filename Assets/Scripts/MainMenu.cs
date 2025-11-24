using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Scene References")]
    public String gameScene;

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(gameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
