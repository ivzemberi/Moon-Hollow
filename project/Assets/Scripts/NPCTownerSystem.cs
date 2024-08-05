using UnityEngine;
using UnityEngine.UI; // Required for Button component
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public string[] dialogueLines;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Button nextButton; // Reference to a UI button to advance dialogue

    private int currentLine = 0;

    void Start()
    {
        dialoguePanel.SetActive(false); // Hide the dialogue panel initially
        dialogueText.text = "";
        
        // Add a listener to the button's click event
        nextButton.onClick.AddListener(NextLine);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartDialogue();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EndDialogue();
        }
    }

    void StartDialogue()
    {
        currentLine = 0;
        dialoguePanel.SetActive(true); // Show the dialogue panel
        UpdateDialogueText();
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false); // Hide the dialogue panel
    }

    void NextLine()
    {
        if (currentLine < dialogueLines.Length)
        {
            currentLine++;
            UpdateDialogueText();
        }

        if (currentLine >= dialogueLines.Length)
        {
            EndDialogue(); // Hide panel after last line
        }
    }

    void UpdateDialogueText()
    {
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
        }
        else
        {
            dialogueText.text = ""; // Clear text if there are no more lines
        }
    }
}
