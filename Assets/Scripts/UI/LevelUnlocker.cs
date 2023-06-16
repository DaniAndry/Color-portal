using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image _lockImage;
    [SerializeField] private UnityEngine.UI.RawImage _colorImage;
    [SerializeField] private ParticleSystem _particle;

    private LevelButton _levelButton;

    public void StartToUnlock(int points)
    {
        _levelButton = GetComponent<LevelButton>();
        Invoke(nameof(Unlock), 1f);
    }

    private void Unlock()
    {
        _particle.Play();
        _lockImage.gameObject.SetActive(false);
        _levelButton.Unlock();

        Color imageColor = _colorImage.color;
        imageColor.a = 1f;
        _colorImage.color = imageColor;
    }

}
