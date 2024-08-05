using UnityEngine;
using TMPro;

public class ToughLuckCanvas : MonoBehaviour
{
    public TextMeshProUGUI infoText;

    public void SetInfoText(string message)
    {
        infoText.text = message;
        Time.timeScale = 1f;
    }
}
