using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class FinishScreen : MonoBehaviour
{
    [SerializeField] private StepCounter _stepCounter;
    [SerializeField] private TextMeshProUGUI _string;
    [SerializeField] private Points _points;

    private int _currentPointsCount;
    private int _maxPointsCount = 3;
    private int _needStepCount;
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
        _needStepCount = 8;
        SelectString();
        SendStepCountEvent();
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

        if (_currentPointsCount != _maxPointsCount)
        {
            if (value > 0 && value > _currentPointsCount)
            {
                int points = value - _currentPointsCount;
                _currentPointsCount = value;
                _points.AddPoints(points);
            }
        }
    }
}
