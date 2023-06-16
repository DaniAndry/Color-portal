using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishScreen : MonoBehaviour
{
    [SerializeField] private StepCounter _stepCounter;
    [SerializeField] private TextMeshProUGUI _string;
    [SerializeField] private Image[] _stars;

    private int _currentPointsCount;
    private int _maxPointsCount = 3;
    private int _needStepCount = 8;
    private string _pointsLevelName;
    private string[] winStrings = new string[]  {
        "Мега круто!",
        "Супер молодец!",
        "Великолепно!",
        "Просто бомба!",
        "Гений уровня!",
        "Ты умница!",
        "Просто огонь !",
        "Шик и блеск!",
        "Мастер!",
        "Просто божественно!",
        "Ты прелесть!",
        "Невероятно талантливо!",
        "Безупречно!",
        "Фантастическое достижение!",
        "Ты Суперзвезда!",
        "Грандиозный успех!",
        "Настоящий ас!",
        "Мастер своего дела!",
        "Просто невероятно!"
    };
    private string[] loseStrings = new string[]    {
        "Можно чуть получше!",
   "Ты можешь лучше!",
   "Неплохо, но можно лучше!",
   "Ещё немного и огонь!",
   "Почти идеально",
   "Близко к совершенству!",
   "Ты на верном пути",
    };

    private void OnEnable()
    {
        SelectString();
        SendStepCountEvent();
    }

    private void Awake()
    {
        _pointsLevelName = "PointsLevel" + SceneManager.GetActiveScene().buildIndex;
        _currentPointsCount = PlayerPrefs.GetInt(_pointsLevelName);
    }

    private void SelectString()
    {
        if (_stepCounter.StepCount <= _needStepCount)
        {
            _string.text = winStrings[Random.Range(0, winStrings.Length)];
        }
        else
        {
            _string.text = loseStrings[Random.Range(0, loseStrings.Length)];
        }
    }

    private void SendStepCountEvent()
    {
        int stepCount = _stepCounter.StepCount;
        int value;

        switch (stepCount)
        {
            case <= 8:
                value = 3;
                break;
            case <= 12:
                value = 2;
                break;
            case <= 15:
                value = 1;
                break;
            default:
                value = 0;
                break;
        }

        if (_currentPointsCount < _maxPointsCount)
        {
            if (value > 0 && value > _currentPointsCount)
            {
                _currentPointsCount = value;
                DisplayStars(_currentPointsCount);
                PlayerPrefs.SetInt(_pointsLevelName, _currentPointsCount);
            }
        }
        else
        {
            DisplayStars(_currentPointsCount);
        }
    }

    private void DisplayStars(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _stars[i].color = new Color(255, 255, 255);
        }
    }
}
