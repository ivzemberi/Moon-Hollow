using UnityEngine;

public class PointCollectable : MonoBehaviour
{
    [SerializeField] private int goldValue; // Value of the collectable item
    [SerializeField] private AudioClip collectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySound(collectSound); // Play collect sound using AudioManager

            if (GameManager.Instance != null && GameManager.Instance.pointCollection != null)
            {
                Debug.Log("Player detected, adding points.");
                GameManager.Instance.pointCollection.AddPoints(goldValue);
                Debug.Log($"Collectable {gameObject.name} added {goldValue} points.");
                gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("GameManager or PointCollection is not initialized.");
            }
        }
    }
}
