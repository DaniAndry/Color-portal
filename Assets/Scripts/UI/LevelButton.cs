using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _blockedClickSound;
    [SerializeField] private bool _isBlocked;

    public int LeveNumber => _levelNumber;

    public void OnClick()
    {
        if (_isBlocked)
        {
            _audioSource.clip = _blockedClickSound;
            _audioSource.Play();
        }
        else
        {
            _audioSource.clip = _clickSound;
            _audioSource.Play();
            _particle.Play();
            StartCoroutine(LoadSceneAfterDelay(0.7f));
        }
    }

    public void Unlock()
    {
        _isBlocked = false;
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(_levelNumber);
    }
}
