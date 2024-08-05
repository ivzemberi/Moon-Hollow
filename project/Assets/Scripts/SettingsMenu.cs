using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound; // Click sound clip

    [Header("Space between Menu Items")]
    [SerializeField] Vector2 spacing;

    [Space]
    [Header("Main Button rotation")]
    [SerializeField] float rotationDuration;
    [SerializeField] Ease rotationEase;

    [Space]
    [Header("Animation")]
    [SerializeField] float expandDuration;
    [SerializeField] float collapseDuration;
    [SerializeField] Ease expandEase;
    [SerializeField] Ease collapseEase;

    [Space]
    [Header("Fading")]
    [SerializeField] float expandFadeDuration;
    [SerializeField] float collapseFadeDuration;

    public GameObject difficultyOverlay; // Reference to the difficulty settings overlay
    public Enemy enemy; // Reference to the Enemy script for setting difficulty


    private Button mainButton;
    private SettingsMenuItem[] menuItems;
    private bool isExpanded = false;

    private Vector2 mainButtonPosition;
    private int itemsCount;

    void Start()
    {
        itemsCount = transform.childCount - 1;
        menuItems = new SettingsMenuItem[itemsCount];
        for (int i = 0; i < itemsCount; i++)
        {
            menuItems[i] = transform.GetChild(i + 1).GetComponent<SettingsMenuItem>();
        }

        mainButton = transform.GetChild(0).GetComponent<Button>();
        mainButton.onClick.AddListener(ToggleMenu);
        mainButton.transform.SetAsLastSibling();

        mainButtonPosition = mainButton.transform.position;

        ResetPositions();
    }

    void ResetPositions()
    {
        for (int i = 0; i < itemsCount; i++)
        {
            menuItems[i].trans.position = mainButtonPosition;
        }
    }

    void ToggleMenu()
    {
        PlayClickSound();
        isExpanded = !isExpanded;
        if (isExpanded)
        {
            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i].trans.DOMove(mainButtonPosition + spacing * (i + 1), expandDuration).SetEase(expandEase);
                menuItems[i].img.DOFade(1f, expandFadeDuration).From(0f);
            }
        }
        else
        {
            for (int i = 0; i < itemsCount; i++)
            {
                menuItems[i].trans.DOMove(mainButtonPosition, collapseDuration).SetEase(collapseEase);
                menuItems[i].img.DOFade(0f, collapseFadeDuration);
            }
        }

        mainButton.transform
            .DORotate(Vector3.forward * 180f, rotationDuration)
            .From(Vector3.zero)
            .SetEase(rotationEase);
    }

    public void OnItemClick(int index)
    {
        PlayClickSound();
        switch (index)
        {
            case 0:
                Debug.Log("Music");
                AudioManager.Instance.ToggleMuteMusic();
                break;
            case 1:
                Debug.Log("Sound");
                AudioManager.Instance.ToggleMuteSound();
                break;
            case 2: 
                Debug.Log("Main-Menu");
                SceneManager.LoadScene("Main-Menu");
                break;
            case 3:
                ToggleDifficultyOverlay(); // Toggle difficulty settings overlay
                break;
        }
    }

    public void ToggleDifficultyOverlay()
    {
        if (difficultyOverlay != null)
        {
            difficultyOverlay.SetActive(!difficultyOverlay.activeSelf); // Toggle overlay visibility
        }
    }

    public void SetDifficultyLevel(int level)
    {
        enemy.difficultyLevel = level;
        enemy.SetDifficulty(level); // Set difficulty level in the Enemy script
        ToggleDifficultyOverlay(); // Hide difficulty overlay after setting
    }

    void OnDestroy()
    {
        mainButton.onClick.RemoveListener(ToggleMenu);
    }

    private void PlayClickSound()
    {
        if (clickSound != null)
        {
            AudioManager.Instance.PlaySound(clickSound);
        }
    }
}
