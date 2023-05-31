using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    private static MusicController instance;
    private AudioSource audioSource;

    private void Awake()
    {
        // Asegúrate de que solo haya un objeto del controlador de música en todas las escenas
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Transfiere el AudioSource al nuevo objeto del controlador de música en la escena cargada
        if (instance != this)
        {
            instance.TransferAudioSource(audioSource);
            Destroy(gameObject);
        }
    }

    private void TransferAudioSource(AudioSource newAudioSource)
    {
        audioSource = newAudioSource;
        audioSource.Play();
    }
}
