using UnityEngine;

public class Riddle : MonoBehaviour
{
    public GameObject riddleOverlayPrefab; // Assign this in the Inspector
    public RiddleData riddleData; // Assign this in the Inspector
    private GameObject riddleOverlayInstance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (riddleOverlayPrefab != null && riddleData != null)
            {
                Time.timeScale = 0f;
                // Instantiate the RiddleOverlay Prefab (RiddleCanvas)
                riddleOverlayInstance = Instantiate(riddleOverlayPrefab);

                // Get the RiddleOverlay component from the instantiated prefab
                RiddleOverlay riddleOverlay = riddleOverlayInstance.GetComponentInChildren<RiddleOverlay>(true);

                if (riddleOverlay != null)
                {
                    // Set the riddle data
                    riddleOverlay.riddleData = riddleData;
                    Debug.Log("Riddle data assigned: " + riddleData.riddleText);

                    // Ensure Initialize is called
                    riddleOverlay.Initialize();
                    Debug.Log("Riddle overlay initialized.");

                    // Optionally, disable the trigger to prevent multiple triggers
                    gameObject.SetActive(false);

                    Debug.Log("Riddle activated");
                }
                else
                {
                    Debug.LogError("RiddleOverlay component not found on instantiated prefab.");
                }
            }
            else
            {
                Debug.LogError("RiddleOverlayPrefab or RiddleData is not assigned in the Inspector.");
            }
        }
    }
}
