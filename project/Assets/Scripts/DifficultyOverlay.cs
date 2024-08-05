using UnityEngine;
using UnityEngine.UI;

public class DifficultyOverlay : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    public SettingsMenu settingsMenu; // Reference to the SettingsMenu script
    public Button easyButton; // Reference to the button for Easy difficulty
    public Button mediumButton; // Reference to the button for Medium difficulty
    public Button hardButton; // Reference to the button for Hard difficulty

    void Start()
    {
        // Add listeners to buttons
        easyButton.onClick.AddListener(SelectEasy);
        mediumButton.onClick.AddListener(SelectMedium);
        hardButton.onClick.AddListener(SelectHard);
    }

    void SelectEasy()
    {
        AudioManager.Instance.PlaySound(clickSound);
        Debug.Log("Difficulty Level = 0");
        settingsMenu.SetDifficultyLevel(0); // Call the SettingsMenu method to set Easy difficulty
    }

    void SelectMedium()
    {
        AudioManager.Instance.PlaySound(clickSound);
        Debug.Log("Difficulty Level = 1");
        settingsMenu.SetDifficultyLevel(1); // Call the SettingsMenu method to set Medium difficulty
    }

    void SelectHard()
    {
        AudioManager.Instance.PlaySound(clickSound);
        Debug.Log("Difficulty Level = 2");
        settingsMenu.SetDifficultyLevel(2); // Call the SettingsMenu method to set Hard difficulty
    }
}
