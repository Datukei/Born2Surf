using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    public int points = 1; // How many points this collectible is worth
    public int requiredAmount; // How many collectibles are required to progress
    public string NextLevel; // Name of the next level

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the colliding object has the "Player" tag
        {
            // Add the collected points to the score
            ScoreManager.Instance.AddScore(points);

            // Check if the required amount of collectibles has been collected
            if (ScoreManager.Instance.currentScore >= requiredAmount)
            {
                // Load the next level
                ScoreManager.Instance.currentScore = 0;
                SceneManager.LoadScene(NextLevel);
            }

            // Destroy the collectible
            Destroy(gameObject);
        }
    }
}
