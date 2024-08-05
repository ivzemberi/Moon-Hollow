using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class RiddleInputChecker : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private AudioClip successSound;
    [SerializeField] private AudioClip failSound;
    public Canvas riddleCanvas;
    public GameObject wellDoneCanvasPrefab; // Assign this in the Inspector
    public GameObject toughLuckCanvasPrefab; // Assign this in the Inspector
    public RiddleData riddleData; // Assign this in the Inspector

    public void ValidateInput()
    {
        if (inputField == null)
        {
            Debug.LogError("InputField is not assigned in the Inspector.");
            return;
        }

        string input = inputField.text;

        if (riddleData == null)
        {
            Debug.LogError("RiddleData is not assigned in the Inspector.");
            return;
        }

        if (riddleData.riddleSolutions == null)
        {
            Debug.LogError("RiddleData's riddleSolutions list is null.");
            return;
        }

        if (riddleData.riddleSolutions.Any(solution => string.Equals(input, solution, StringComparison.OrdinalIgnoreCase)))
        {
            AudioManager.Instance.PlaySound(successSound);

            if (riddleCanvas != null)
            {
                riddleCanvas.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("RiddleCanvas is not assigned.");
                return;
            }

            if (wellDoneCanvasPrefab != null)
            {
                // Instantiate WellDoneCanvas prefab
                GameObject wellDoneCanvasInstance = Instantiate(wellDoneCanvasPrefab);
                WellDoneCanvas wellDoneCanvas = wellDoneCanvasInstance.GetComponent<WellDoneCanvas>();

                if (wellDoneCanvas != null)
                {
                    wellDoneCanvas.SetSolutionText(input);
                }
                else
                {
                    Debug.LogError("WellDoneCanvas component not found on instantiated prefab.");
                }
            }
            else
            {
                Debug.LogError("WellDoneCanvasPrefab is not assigned in the Inspector.");
            }

            if (GameManager.Instance != null && GameManager.Instance.pointCollection != null)
            {
                GameManager.Instance.pointCollection.AddPoints(riddleData.riddleValue);
            }
            else
            {
                Debug.LogError("GameManager or its PointCollection is not assigned.");
            }
        }
        else
        {
            AudioManager.Instance.PlaySound(failSound);

            if (riddleCanvas != null)
            {
                riddleCanvas.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("RiddleCanvas is not assigned.");
                return;
            }

            if (toughLuckCanvasPrefab != null)
            {
                // Instantiate ToughLuckCanvas prefab
                GameObject toughLuckCanvasInstance = Instantiate(toughLuckCanvasPrefab);
                ToughLuckCanvas toughLuckCanvas = toughLuckCanvasInstance.GetComponent<ToughLuckCanvas>();

                if (toughLuckCanvas != null)
                {
                    //string message = "Tough luck! The correct answer was: " + string.Join(", ", riddleData.riddleSolutions);
                    string message = "Tough luck! The correct answer was: " + riddleData.riddleSolutions[0];
                    toughLuckCanvas.SetInfoText(message);
                }
                else
                {
                    Debug.LogError("ToughLuckCanvas component not found on instantiated prefab.");
                }
            }
            else
            {
                Debug.LogError("ToughLuckCanvasPrefab is not assigned in the Inspector.");
            }
        }
    }
}
