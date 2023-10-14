using UnityEngine;
using UnityEngine.SceneManagement;

public class BonusSystem : MonoBehaviour
{
    [SerializeField] private Stopwatch _stopwatch;
    [SerializeField] private FinalCube _finalCube;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private FinishScreen _finishScreen;

    private float _basePointsPerSecond = 300f;
    private int _currentLevel;
    private int _currentPoints;
    private bool _isBonusUsed;

    private void Start()
    {
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
        _finalCube.Finished += LevelComplete;
    }

    public void AddBonus()
    {
        _isBonusUsed = true;
        _currentPoints = 0;
        LevelComplete();
        _finishScreen.SendStepCountEvent();
    }

    private void CalculateBonusPoints()
    {
        float elapsedTime = _stopwatch.GetTime();
        float bonusPointsPerSecond = _basePointsPerSecond / elapsedTime;
        int maxCountStars = 3;
        int stars = PlayerPrefs.GetInt("PointsLevel" + _currentLevel, 0);

        if (stars < maxCountStars && _isBonusUsed)
        {
            stars += 1;
            PlayerPrefs.SetInt("PointsLevel" + _currentLevel, stars);
        }

        _currentPoints += (int)bonusPointsPerSecond;

        int bonusFromStars = stars * 50;
        _currentPoints += bonusFromStars;
    }

    private void LevelComplete()
    {
        int currentScoreCount = PlayerPrefs.GetInt("ScoreCount" + _currentLevel);
        int bonusMultiplier = 2;

        CalculateBonusPoints();

        if (_isBonusUsed)
        {
            _currentPoints *= bonusMultiplier;
        }
        if (currentScoreCount < _currentPoints)
        {
            _scoreCounter.SetScore(_currentPoints);
            PlayerPrefs.SetInt("ScoreCount" + _currentLevel, _currentPoints);
        }
        else
        {
            _scoreCounter.SetScore(_currentPoints);
        }
    }
}
