using UnityEngine;

public class RainDrop : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered with: " + other.name);

        ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();

        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found!");
            return;
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit Player!");
            scoreManager.AddScore(1);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            Debug.Log("Hit Ground!");
            scoreManager.AddScore(-1);
            Destroy(gameObject);
        }
    }
}
