using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class FinalCube : Cube
{
    public event UnityAction Finished;

    [SerializeField] private List<ParticleSystem> _particles;
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private GameObject _gamePanel;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _applause;
    [SerializeField] private AudioClip _win;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            StartCoroutine(PlayWinAudio());
            foreach (ParticleSystem particle in _particles)
            {
                particle.Play();
            }

            Invoke(nameof(ActivatePanel), 1f);
            Destroy(player.gameObject);
        }
    }

    private IEnumerator PlayWinAudio()
    {
        _audioSource.clip = _win;
        _audioSource.Play();

        while (_audioSource.isPlaying)
        {
            yield return null;
        }

        _audioSource.clip = _applause;
        _audioSource.Play();
    }

    private void ActivatePanel()
    {
        _finishPanel.SetActive(true);
        _gamePanel.SetActive(false);
        Finished?.Invoke();
    }
}
