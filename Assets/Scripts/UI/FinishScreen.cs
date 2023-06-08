using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishScreen : MonoBehaviour
{
    [SerializeField] private StepCounter _stepCounter;
    [SerializeField] private TextMeshProUGUI _string;

    private int _needStepCount;
    private string[] WinStrings = new string[]
    { "Мега круто!",
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

    private string[] LoseStrings = new string[]
    { "Можно чуть получше!",
   "Ты можешь лучше!",
   "Неплохо, но можно лучше!",
   "Ещё немного и огонь!",
   "Почти идеально",
   "Близко к совершенству!",
   "Ты на верном пути",
    };

    private void OnEnable()
    {
        _needStepCount = 9;
        SelectString();
    }

    private void SelectString()
    {
        if (_stepCounter.StepCount <= _needStepCount)
        {
            _string.text = WinStrings[Random.Range(0, WinStrings.Length)];
        }
        else
        {
            _string.text = LoseStrings[Random.Range(0, LoseStrings.Length)];
        }
    }
}
