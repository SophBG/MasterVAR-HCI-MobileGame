using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Match Stats")]
    public TextMeshProUGUI pointsHUD;
    public TextMeshProUGUI pointsFinal;
    private int points;

    [Header("Input Actions")]
    public InputActionAsset inputActions;

    [Header("Panel References")]
    public GameObject gameOverPanel;
    public GameObject hudPanel;

    [Header("Scene References")]
    public string mainMenuScene;
    public string gameScene;

    public void Start()
    {
        points = 0;
        UpdateText();

        hudPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void AddPoint()
    {
        points++;
        UpdateText();
    }

    public void GameOver()
    {
        hudPanel.SetActive(false);
        gameOverPanel.SetActive(true);

        // Pause the game
        Time.timeScale = 0f;

        // Disable input when game over
        if (inputActions != null)
        {
            inputActions.FindActionMap("Player").Disable();
        }

        UpdateText();
    }

    private void UpdateText()
    {
        pointsHUD.text = "" + points;
        pointsFinal.text = "Total points: " + points;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(gameScene);
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(mainMenuScene);
    }
}
