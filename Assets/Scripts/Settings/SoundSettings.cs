using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _sound;
    [SerializeField] private AudioSource _finish;

    [SerializeField] private Image _soundImage;
    [SerializeField] private Image _musicImage;
    [SerializeField] private Image _soundImageStop;
    [SerializeField] private Image _musicImageStop;

    private bool _isMusic;
    private bool _isSound;

    private void Start()
    {
        _music.volume = PlayerPrefs.GetFloat("MusicVolume");
        _sound.volume = PlayerPrefs.GetFloat("SoundVolume");
        _finish.volume = PlayerPrefs.GetFloat("SoundVolume");
        _isMusic = PlayerPrefs.GetFloat("MusicVolume") > 0;
        _isSound = PlayerPrefs.GetFloat("SoundVolume") > 0;

        ChangeImage();
    }


    public void SwichVolumeMusic()
    {
        if (_music.volume == 0)
        {
            PlayerPrefs.SetFloat("MusicVolume", 100f);
            _music.volume = PlayerPrefs.GetFloat("MusicVolume");
            _isMusic = true;
            ChangeImage();
        }
        else
        {
            PlayerPrefs.SetInt("MusicVolume", 0);
            _music.volume = PlayerPrefs.GetFloat("MusicVolume");
            _isMusic = false;
            ChangeImage();
        }
    }

    public void SwichVolumeSound()
    {
        if (!_isSound)
        {
            PlayerPrefs.SetFloat("SoundVolume", 100);
            _sound.volume = PlayerPrefs.GetFloat("SoundVolume");
            _finish.volume = PlayerPrefs.GetFloat("SoundVolume");
            _isSound = true;
            ChangeImage();
        }
        else
        {
            PlayerPrefs.SetFloat("SoundVolume", 0);
            PlayerPrefs.SetFloat("SoundVolume", 0);
            _sound.volume = PlayerPrefs.GetFloat("SoundVolume");
            _finish.volume = PlayerPrefs.GetFloat("SoundVolume");
            _isSound = false;
            ChangeImage();
        }
    }

    private void ChangeImage()
    {
        if (!_isMusic)
        {
            _musicImage.gameObject.SetActive(false);
            _musicImageStop.gameObject.SetActive(true);
        }
        else
        {
            _musicImageStop.gameObject.SetActive(false);
            _musicImage.gameObject.SetActive(true);
        }

        if (!_isSound)
        {
            _soundImage.gameObject.SetActive(false);
            _soundImageStop.gameObject.SetActive(true);
        }
        else
        {
            _soundImage.gameObject.SetActive(true);
            _soundImageStop.gameObject.SetActive(false);
        }
    }
}
