using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    public void EnterGame()
    {
        AudioManager.Instance.PlaySound(clickSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
