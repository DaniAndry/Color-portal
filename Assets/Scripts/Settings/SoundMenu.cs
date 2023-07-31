using UnityEngine;

public class SoundMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    private Focus _focus;

    private void Start()
    {
        _focus = GetComponent<Focus>();
        _focus.FocusMissing += StopSounds;
        _focus.FocusIsBack += PlaySounds;
    }

    private void OnDisable()
    {
        _focus.FocusMissing -= StopSounds;
        _focus.FocusIsBack -= PlaySounds;
    }

    private void StopSounds()
    {
        _music.Pause();

    }
    private void PlaySounds()
    {
        _music.Play();
    }
}
