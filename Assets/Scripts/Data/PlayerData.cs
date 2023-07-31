using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int _playerPoints;
    private int _scoreCount;

    public int PlayerPoints => _playerPoints;
    public int ScoreCount => _scoreCount;

    public PlayerData SetPlayerData(int playerPoints, int scoreCount)
    {
        _playerPoints = playerPoints;
        _scoreCount = scoreCount;
        return this;
    }
}
