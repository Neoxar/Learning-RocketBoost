using System;
using System.Linq;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandller : MonoBehaviour
{
    [SerializeField] private float _sceneLoadDelay = 2f;
    [SerializeField] private AudioClip _successSFX;
    [SerializeField] private AudioClip _crashSFX;
    [SerializeField] private ParticleSystem _successParticles;
    [SerializeField] private ParticleSystem _crashParticles;

    private AudioSource _audioSource;

    private bool _isControlable = true;
    private bool _isCollidable = true;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RespondeToDebugKey();
    }

    private void RespondeToDebugKey()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            LoadNextLevel();
        }
        else if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            _isCollidable = !_isCollidable;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_isControlable || !_isCollidable) { return; }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                StartSceneSequence(nameof(LoadNextLevel), _successSFX, _successParticles);
                break;
            default:
                StartSceneSequence(nameof(ReloadLevel), _crashSFX, _crashParticles);
                break;
        }
    }

    private void StartSceneSequence(string methodName, AudioClip audioClip, ParticleSystem particles)
    {
        _isControlable = false;
        _audioSource.Stop();
        _audioSource.PlayOneShot(audioClip);
        particles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke(methodName, _sceneLoadDelay);
    }

    private void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
