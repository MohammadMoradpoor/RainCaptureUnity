using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // For reloading the scene

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;
    public GameObject tryAgainButton;   // Try Again button
    public RainSpawner rainSpawner;
    public int gameOverScore = -10;

    private bool isGameOver = false;

    void Start()
    {
        Debug.Log("ScoreManager initialized");
        UpdateUI();

        if (gameOverText != null)
            gameOverText.SetActive(false);

        if (tryAgainButton != null)
            tryAgainButton.SetActive(false); // Hide button at start of game
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;
        Debug.Log("Score increased by " + amount + ". New score: " + score);
        UpdateUI();

        if (score <= gameOverScore)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    void GameOver()
    {
        isGameOver = true;

        Debug.Log("Game Over!");
        if (gameOverText != null)
            gameOverText.SetActive(true);

        if (tryAgainButton != null)
            tryAgainButton.SetActive(true);

        Time.timeScale = 0f; // Complete game pause
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Return to normal time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload scene
    }
}
