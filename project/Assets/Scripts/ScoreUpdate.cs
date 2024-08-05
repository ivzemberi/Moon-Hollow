using UnityEngine;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        if (GameManager.Instance != null && GameManager.Instance.pointCollection != null)
        {
            GameManager.Instance.pointCollection.OnScoreChanged += HandleScoreChanged;
            UpdateScoreUI();
        }
        else
        {
            Debug.LogError("GameManager or PointCollection is not initialized.");
        }
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null && GameManager.Instance.pointCollection != null)
        {
            GameManager.Instance.pointCollection.OnScoreChanged -= HandleScoreChanged;
        }
    }

    private void HandleScoreChanged(int newScore)
    {
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        if (scoreText != null && GameManager.Instance != null && GameManager.Instance.pointCollection != null)
        {
            scoreText.SetText(GameManager.Instance.pointCollection.Score.ToString());
        }
    }
}
