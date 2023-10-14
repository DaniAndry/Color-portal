using Agava.YandexGames;
//using Agava.VKGames;
using UnityEngine;

public class StartWindow : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _leaderboard;
    [SerializeField] private GameObject _leaderboardButton;
    [SerializeField] private GameObject _leaderboardMessage;

    private bool _isStartPanelActive;
    private bool _isSettingsPanelActive;
    private bool _isLeaderboardActive;
    private bool _isMenuPanelActive;


    private void Start()
    {
        YandexGamesSdk.GameReady();
    }

    public void StartGame()
    {
        _isStartPanelActive = _startPanel.activeSelf;
        _isSettingsPanelActive = _settingsPanel.activeSelf;
        _isLeaderboardActive = _leaderboard.activeSelf;
        _menuPanel.SetActive(true);
        _startPanel.SetActive(false);
        _leaderboardButton.SetActive(false);
    }

    public void OpenSettings()
    {
        _isStartPanelActive = _startPanel.activeSelf;
        _isLeaderboardActive = _leaderboard.activeSelf;
        _startPanel.SetActive(false);
        _settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        _settingsPanel.SetActive(false);
        _startPanel.SetActive(true);
    }

    public void OpenLeaderboard()
    {
        RemeberElements();

        if (PlayerAccount.IsAuthorized)
        {
            _leaderboard.SetActive(true);
            _leaderboardButton.SetActive(false);
            CloseMenuElement();
        }
        else
        {
            OpenLeaderboardMessage();
        }
    }


    public void CloseLeaderboard()
    {
        _leaderboard.SetActive(false);
        OpenMenuElement();
    }

    public void OpenLeaderboardMessage()
    {
        _leaderboardMessage.SetActive(true);
        CloseMenuElement();
    }

    public void Agrement()
    {
        CloseLeaderboardMessage();
        PlayerAccount.Authorize();
    }

    public void CloseMenu()
    {
        _startPanel.SetActive(true);
        _leaderboardButton.SetActive(true);
        _menuPanel.SetActive(false);
    }

    public void CloseLeaderboardMessage()
    {
        _leaderboardMessage.SetActive(false);
        OpenMenuElement();
    }

    private void CloseMenuElement()
    {
        RemeberElements();
        _settingsPanel.SetActive(false);
        _startPanel.SetActive(false);
        _menuPanel.SetActive(false);
    }

    private void OpenMenuElement()
    {
        _leaderboardButton.SetActive(true);
        _startPanel.SetActive(_isStartPanelActive);
        _settingsPanel.SetActive(_isSettingsPanelActive);
        _menuPanel.SetActive(_isMenuPanelActive);
    }

    private void RemeberElements()
    {
        _isStartPanelActive = _startPanel.activeSelf;
        _isSettingsPanelActive = _settingsPanel.activeSelf;
        _isMenuPanelActive = _menuPanel.activeSelf;
    }
}
