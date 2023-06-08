using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _step;
    [SerializeField] private AudioClip _teleport;

    [SerializeField] private PlayerTeleport _playerTeleport;
    [SerializeField] private PlayerMover _playerMover;

    private void OnEnable()
    {
        _playerTeleport.Teleported += PlayTeleportSound;
        _playerMover.Moved += PlayStepSound;
    }

    private void OnDisable()
    {
        _playerTeleport.Teleported -= PlayTeleportSound;
        _playerMover.Moved -= PlayStepSound;
    }

    private void PlayTeleportSound()
    {
        _audioSource.clip = _teleport;
        _audioSource.Play();
    }

    private void PlayStepSound()
    {
        _audioSource.clip = _step;
        _audioSource.Play();
    }
}
