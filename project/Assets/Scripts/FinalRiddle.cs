using UnityEngine;
using TMPro;

public class FinalRiddleTrigger : MonoBehaviour
{
    public Canvas finalRiddleCanvas; // Reference to the FinalRiddleCanvas
    public string correctAnswer = "Darkness"; // The correct answer for the riddle
    public GameObject gameOverScreen; // Reference to the GameOver screen
    public GameObject gameWonScreen; // Reference to the GameWon screen

    private TMP_InputField answerInputField; // Reference to the TMP_InputField for the player's answer

    private void Start()
    {
        // Find the TMP_InputField component in the FinalRiddleCanvas
        if (finalRiddleCanvas != null)
        {
            answerInputField = finalRiddleCanvas.GetComponentInChildren<TMP_InputField>();
            if (answerInputField == null)
            {
                Debug.LogError("TMP_InputField component not found in FinalRiddleCanvas.");
            }
        }
        else
        {
            Debug.LogError("FinalRiddleCanvas reference is not assigned.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PauseGame();
            ShowFinalRiddleCanvas();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game by setting the time scale to 0
    }

    private void ShowFinalRiddleCanvas()
    {
        finalRiddleCanvas.gameObject.SetActive(true);
    }

    public void CheckAnswer()
    {
        if (answerInputField != null)
        {
            string playerAnswer = answerInputField.text;

            if (playerAnswer.Equals(correctAnswer, System.StringComparison.OrdinalIgnoreCase))
            {
                GameWon();
            }
            else
            {
                GameOver();
            }
        }
        else
        {
            Debug.LogError("AnswerInputField reference is not assigned.");
        }
    }

    private void GameOver()
    {
        finalRiddleCanvas.gameObject.SetActive(false);
        ResumeGame();

        // Show the game over screen with the score
        if (gameOverScreen != null && GameManager.Instance != null && GameManager.Instance.pointCollection != null)
        {
            int finalScore = GameManager.Instance.pointCollection.Score;
            gameOverScreen.GetComponent<GameOverScreen>().Setup(finalScore);
            gameOverScreen.SetActive(true);
        }
        else
        {
            Debug.LogError("GameOverScreen, GameManager, or PointCollection is not properly assigned.");
        }
    }

    private void GameWon()
    {
        finalRiddleCanvas.gameObject.SetActive(false);
        ResumeGame();

        // Show the game won screen with the score
        if (gameWonScreen != null && GameManager.Instance != null && GameManager.Instance.pointCollection != null)
        {
            int finalScore = GameManager.Instance.pointCollection.Score;
            gameWonScreen.GetComponent<GameOverScreen>().Setup(finalScore);
            gameWonScreen.SetActive(true);
        }
        else
        {
            Debug.LogError("GameWonScreen, GameManager, or PointCollection is not properly assigned.");
        }
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game by setting the time scale back to 1
    }
}
