using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class music : MonoBehaviour
{
    public AudioClip musicClip; // Assign the music clip in the Inspector
    private AudioSource audioSource;

    private void Awake()
    {
        // Make sure this GameObject persists between scenes
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();

        // Set up the AudioSource properties
        audioSource.clip = musicClip;
        audioSource.loop = true;

        // Play the music
        audioSource.Play();
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Resume playing music after scene change (if it was paused during loading)
        audioSource.Play();
    }
}
