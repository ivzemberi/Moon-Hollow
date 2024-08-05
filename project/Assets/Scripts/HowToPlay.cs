using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    public void BackButton()
    {
        AudioManager.Instance.PlaySound(clickSound);
        SceneManager.LoadScene("Main-Menu");
    }
}
