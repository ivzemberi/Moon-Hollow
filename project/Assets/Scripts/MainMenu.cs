using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    public void PlayGame()
    {
        AudioManager.Instance.PlaySound(clickSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void HowToPlayGame()
    {
        AudioManager.Instance.PlaySound(clickSound);
        SceneManager.LoadScene("How-To-Play");
    }

    public void AboutGame()
    {
        AudioManager.Instance.PlaySound(clickSound);
        SceneManager.LoadScene("About-Game");
    }
    
    public void QuitGame()
    {
        AudioManager.Instance.PlaySound(clickSound);
        Application.Quit();
    }
}
