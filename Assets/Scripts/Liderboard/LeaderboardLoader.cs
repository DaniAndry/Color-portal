using Agava.YandexGames;
using UnityEngine;

public class LeaderboardLoader : MonoBehaviour
{
    private const int MaxRecordsToShow = 7;

    private string _anonymous;

    [SerializeField] private Score[] _scores;
    [SerializeField] private PlayerScore _playerScore;

    private string _leaderboardName = "Score";
    private string _currentLanguage;
    private int _currentScore;

    public string LeaderboardName => _leaderboardName;

    private void Start()
    {
        _currentScore = PlayerPrefs.GetInt("PlayerPoints");
        DisableAllRecords();
        _currentLanguage = PlayerPrefs.GetString("_currentLanguage");
        SelectLanguage(_currentLanguage);
#if UNITY_WEBGL && !UNITY_EDITOR
  
       Leaderboard.SetScore("Score", _currentScore);
        
        LoadYandexLeaderboard();
#endif
    }

    private void DisableAllRecords()
    {
        _playerScore.gameObject.SetActive(false);

        foreach (var score in _scores)
        {
            score.gameObject.SetActive(false);
        }
    }
    private void SelectLanguage(string language)
    {
        switch (language)
        {
            case "ru":
                _anonymous = "���������";
                break;
            case "en":
                _anonymous = "Anonymous";
                break;
            case "tr":
                _anonymous = "anonim";
                break;
            default:
                _anonymous = "���������";
                break;
        }
    }

    private void LoadYandexLeaderboard()
    {
        PlayerAccount.RequestPersonalProfileDataPermission();

        if (PlayerAccount.IsAuthorized == false)
        {
            PlayerAccount.Authorize();
        }

        Leaderboard.GetEntries(_leaderboardName, (result) =>
        {
            int recordsToShow =
                result.entries.Length <= MaxRecordsToShow ? result.entries.Length : MaxRecordsToShow;

            for (int i = 0; i < recordsToShow; i++)
            {
                string name = result.entries[i].player.publicName;

                if (string.IsNullOrEmpty(name))
                {
                    name = _anonymous;
                }

                _scores[i].SetName(name);
                _scores[i].SetScore(result.entries[i].formattedScore);
                _scores[i].gameObject.SetActive(true);
            }
        });

        LoadPlayerScore();
    }

    private void LoadPlayerScore()
    {
        if (YandexGamesSdk.IsInitialized)
        {
            Leaderboard.GetPlayerEntry(_leaderboardName, OnSuccessCallback);
        }
    }

    private void OnSuccessCallback(LeaderboardEntryResponse result)
    {
        if (result != null)
        {
            _playerScore.gameObject.SetActive(true);
            _playerScore.SetName(result.player.publicName);
            _playerScore.SetScore(result.score.ToString());
            _playerScore.SetRank(result.rank);
        }
        else
        {
            _playerScore.gameObject.SetActive(false);
        }
    }
}