using UnityEngine;
using UnityEngine.SceneManagement;

public class BonusSystem : MonoBehaviour
{
    [SerializeField] private Stopwatch _stopwatch;
    [SerializeField] private FinalCube _finalCube;
    [SerializeField] private ScoreCounter _scoreCounter;

    private float _basePointsPerSecond = 300f;
    private int _currentLevel;
    private int _currentPoints;

    private void Start()
    {
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
        _finalCube.Finished += LevelComplete;
    }

    private void CalculateBonusPoints()
    {
        float elapsedTime = _stopwatch.GetTime();
;
        float bonusPointsPerSecond = _basePointsPerSecond / elapsedTime;

        Debug.Log("Время" + bonusPointsPerSecond);
        int points = PlayerPrefs.GetInt("PointsLevel" + _currentLevel, 0);
        _currentPoints += (int)bonusPointsPerSecond;

        int bonusFromStars = points * 50;
        _currentPoints += bonusFromStars;
    }

    private void LevelComplete()
    {
        CalculateBonusPoints();
        _scoreCounter.SetScore(_currentPoints);
    }
}
