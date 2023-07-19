using UnityEngine;

public class LeaderboardOpener : MonoBehaviour
{
    [SerializeField] private GameObject _leaderboard;

    public void OpenLeaderboard()
    {
        _leaderboard.SetActive(true);
    }

    public void CloseLeaderboard()
    {
        _leaderboard.SetActive(false);
    }
}
