using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    public GameOverScreen gameOverScreen; // Reference to the GameOverScreen
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // Player hurt
            // TODO: Add animations for getting hurt
        }
        else
        {
            // Player dead
            if (!dead)
            {
                GetComponent<PlayerMovement>().enabled = false;
                Time.timeScale = 0f;
                dead = true;
                // TODO: Add game over screen
                ShowGameOverScreen(); // Call method to show game over screen
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private void ShowGameOverScreen()
    {
        if (gameOverScreen != null && GameManager.Instance != null && GameManager.Instance.pointCollection != null)
        {
            int finalScore = GameManager.Instance.pointCollection.Score;
            gameOverScreen.Setup(finalScore);
        }
        else
        {
            Debug.LogError("GameOverScreen or GameManager is not assigned or PointCollection is not initialized.");
        }
    }
}
