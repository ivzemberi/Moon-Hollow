using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClickSound : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    
    public void PlaySound()
    {
        AudioManager.Instance.PlaySound(clickSound);
    }
}
