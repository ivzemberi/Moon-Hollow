using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip gameOverSound;
    public TextMeshProUGUI pointsText;
    public void Setup(int score)
    {
        AudioManager.Instance.PlaySound(gameOverSound);
        gameObject.SetActive(true);
        pointsText.SetText(score.ToString() + " POINTS");
    }

    public void RestartButton()
    {
        AudioManager.Instance.PlaySound(clickSound);

        // Reset the score
        if (GameManager.Instance != null && GameManager.Instance.pointCollection != null)
        {
            GameManager.Instance.pointCollection.ResetScore();
        }

        
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void ExitButton()
    {
        AudioManager.Instance.PlaySound(clickSound);

        // Reset the score
        if (GameManager.Instance != null && GameManager.Instance.pointCollection != null)
        {
            GameManager.Instance.pointCollection.ResetScore();
        }


        SceneManager.LoadScene("Main-Menu");
    }
}
