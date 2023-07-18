using UnityEngine;
using UnityEngine.SceneManagement;

public class StartWindow : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _menuPanel;

    public void StartGame()
    {
       _menuPanel.gameObject.SetActive(true);
        _startPanel.gameObject.SetActive(false);

    }

    public void OpenSettings()
    {
        _settingsPanel.gameObject.SetActive(true);
        _startPanel.gameObject.SetActive(false);
    }

    public void CloseSettings()
    {
        _settingsPanel.gameObject.SetActive(false);
        _startPanel.gameObject.SetActive(true);
    }
}
