using UnityEngine;
using TMPro;

public class WellDoneCanvas : MonoBehaviour
{
    public TextMeshProUGUI solutionText;

    public void SetSolutionText(string solution)
    {
        solutionText.text = $"Well done! The answer was of course:\n{solution}!";
        Time.timeScale = 1f;
    }
}