using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _mainPanel;

    public void OpenMenu()
    {
        _mainPanel.SetActive(true);
    }

    public void CloseMenu()
    {
        _mainPanel.SetActive(false);
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
