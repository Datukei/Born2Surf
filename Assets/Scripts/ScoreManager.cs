using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; } // Singleton pattern
    public int currentScore = 0; // Current score

   
    private void Awake()
    {
        // Singleton pattern: Ensure there's only one instance of this script
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Keep this object across scenes
    }

    // Add score
    public void AddScore(int points)
    {
        currentScore += points;
    }
}