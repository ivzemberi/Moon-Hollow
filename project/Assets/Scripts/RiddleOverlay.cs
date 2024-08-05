using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RiddleOverlay : MonoBehaviour
{
    public Button giveUpButton;
    public Button guessButton;
    public TextMeshProUGUI riddleText;
    public TextMeshProUGUI titleText;
    public RiddleData riddleData; // Reference to the ScriptableObject

    public void Initialize()
    {
        // Initialize the riddle text from the ScriptableObject
        if (riddleData != null)
        {
            Debug.Log("Initializing riddle overlay with riddle text: " + riddleData.riddleText);
            riddleText.text = riddleData.riddleText;
        }
        else
        {
            Debug.LogError("RiddleData is not assigned.");
        }
    }
}
