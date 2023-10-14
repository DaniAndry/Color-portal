using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _clock;

    private bool _isOpen;

    public bool isOpen => _isOpen;

    public void OpenMenu()
    {
        _mainPanel.SetActive(true);
        _clock.SetActive(false);
        _isOpen = true;
    }

    public void CloseMenu()
    {
        _mainPanel.SetActive(false);
        _clock.SetActive(true);
        _isOpen = false;
    }

    public void OpenSettings()
    {
        _mainPanel.SetActive(false);
        _settingsPanel.SetActive(true);
    }


    public void CloseSettings()
    {
        _mainPanel.SetActive(true);
        _settingsPanel.SetActive(false);
    }
}
