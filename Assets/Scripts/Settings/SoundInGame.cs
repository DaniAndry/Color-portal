using UnityEngine;

public class SoundInGame : MonoBehaviour
{
    [SerializeField] private Focus _focus;
    [SerializeField] private Ad _ad;

    private bool _isAdPlaying;

    private void Start()
    {
        _focus.FocusIsBack += EnableFocus;
        _focus.FocusMissing += DisableFocus;
    }

    public void StopSounds()
    {
        Debug.Log("StopSound");
        AudioListener.pause = true;
        AudioListener.volume = 0f;
    }
    public void PlaySounds()
    {
        Debug.Log("PlaySound");
        AudioListener.pause = false;
        AudioListener.volume = 1f;
    }

    private void EnableFocus()
    {
        if (_ad.IsRun == false)
        {
            PlaySounds();
        }
    }

    private void DisableFocus()
    {
        if (_ad.IsRun == false)
        {
            StopSounds();
        }
    }
}
