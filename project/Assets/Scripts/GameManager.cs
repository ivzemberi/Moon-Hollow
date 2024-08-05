using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public ScoreUpdate globalScoreUpdater; // Reference to ScoreUpdate for global score management
    public PointCollection pointCollection;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep GameManager alive between scenes if needed

            pointCollection = new PointCollection();
            pointCollection.OnScoreChanged += HandleScoreChanged;
        }
        else
        {
            Destroy(gameObject); // Ensure only one GameManager instance
        }
    }

    private void HandleScoreChanged(int newScore)
    {
        if (globalScoreUpdater != null)
        {
            globalScoreUpdater.UpdateScoreUI();
        }
    }
}
