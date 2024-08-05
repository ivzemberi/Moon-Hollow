using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSourcePrefab; // Assign your music source prefab in the Inspector
    private AudioSource currentMusicSource; // This will be dynamically assigned

    [Header("Audio Source Pool Settings")]
    public int poolSize = 10; // Number of AudioSources to create in the pool
    private List<AudioSource> soundSources;

    private bool isMusicMuted = false;
    private bool isSoundMuted = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeSoundSources(); // Initialize the pool of AudioSources
            SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to scene loaded event
            AssignMusicSource(); // Assign music source on Awake
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitializeSoundSources()
    {
        soundSources = new List<AudioSource>();
        for (int i = 0; i < poolSize; i++)
        {
            // Create a new AudioSource component and add it to the GameObject this script is attached to
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.playOnAwake = false; // Ensure the AudioSource does not play automatically
            soundSources.Add(source); // Add the AudioSource to the pool
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignMusicSource();
    }

    void AssignMusicSource()
    {
        if (currentMusicSource == null)
        {
            // Instantiate a new music source if none exists
            currentMusicSource = Instantiate(musicSourcePrefab, transform.position, Quaternion.identity);
            currentMusicSource.transform.SetParent(transform);
            currentMusicSource.mute = isMusicMuted;
            DontDestroyOnLoad(currentMusicSource.gameObject);
        }
        else
        {
            Debug.Log("Current Music Source already exists: " + currentMusicSource.gameObject.name);
        }

        Debug.Log("Current Music Source: " + currentMusicSource.gameObject.name);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (currentMusicSource != null && !isMusicMuted)
        {
            currentMusicSource.clip = clip;
            currentMusicSource.Play();
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (!isSoundMuted)
        {
            AudioSource source = GetAvailableSoundSource();
            source.clip = clip;
            source.Play();
        }
    }

    AudioSource GetAvailableSoundSource()
    {
        // Find an available AudioSource that is not currently playing
        foreach (AudioSource source in soundSources)
        {
            if (!source.isPlaying)
            {
                return source;
            }
        }
        return soundSources[0]; // If all are playing, return the first one (or handle overflow as needed)
    }

    public void ToggleMuteMusic()
    {
        isMusicMuted = !isMusicMuted;
        Debug.Log("Music muted state: " + isMusicMuted);
        if (currentMusicSource != null)
        {
            currentMusicSource.mute = isMusicMuted;
        }
    }

    public void ToggleMuteSound()
    {
        isSoundMuted = !isSoundMuted;
        foreach (AudioSource source in soundSources)
        {
            source.mute = isSoundMuted;
        }
    }
}
