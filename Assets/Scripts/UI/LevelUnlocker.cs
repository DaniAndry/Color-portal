using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image _lockImage;
    [SerializeField] private UnityEngine.UI.RawImage _colorImage;
    [SerializeField] private Points _points;
    [SerializeField] private int _needPointCount;
    [SerializeField] private ParticleSystem _particle;

    private LevelButton _levelButton;

    private void Start()
    {
        _levelButton = GetComponent<LevelButton>();

        if (_points.Count >= _needPointCount)
        {
            Invoke(nameof(Unlock), 1f);
        }
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
