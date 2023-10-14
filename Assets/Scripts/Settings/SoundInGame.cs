using UnityEngine;

public class SoundInGame : MonoBehaviour
{
    [SerializeField] private Focus _focus;
    [SerializeField] private Ad _ad;


    private void Start()
    {
        _focus.FocusIsBack += EnableFocus;
        _focus.FocusMissing += DisableFocus;
    }

    private void OnDisable()
    {
        _focus.FocusIsBack -= EnableFocus;
        _focus.FocusMissing -= DisableFocus;
    }

    public void StopSounds()
    {
        Debug.Log("StopSound");
        Debug.Log(_ad.IsRun);
        AudioListener.pause = true;
        AudioListener.volume = 0f;
    }

    public void PlaySounds()
    {
        Debug.Log(_ad.IsRun);
        Debug.Log("PlaySound");
        AudioListener.pause = false;
        AudioListener.volume = 1f;
    }

    private void EnableFocus()
    {
        if (!_ad.IsRun)
        {
            PlaySounds();
        }
    }

    private void DisableFocus()
    {
        StopSounds();

    }
}
