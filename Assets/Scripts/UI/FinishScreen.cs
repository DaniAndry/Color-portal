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
    private string _currentLanguage;

    private string[] _currentWinStrigs;
    private string[] _currentLoseStrigs;
    private string[] _winStringsRussian = new string[] {
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

    private string[] _loseStringsRussian = new string[] {
        "Можно чуть получше!",
        "Ты можешь лучше!",
        "Неплохо, но можно лучше!",
        "Ещё немного и огонь!",
        "Почти идеально",
        "Близко к совершенству!",
        "Ты на верном пути",
    };

    private string[] _winStringsEnglish = new string[] {
        "Awesome!",
        "Well done!",
        "Great job!",
        "Simply fantastic!",
        "Genius level!",
        "You're brilliant!",
        "Just amazing!",
        "Chic and glamorous!",
        "Masterful!",
        "Simply divine!",
        "You're lovely!",
        "Incredibly talented!",
        "Flawless!",
        "Fantastic achievement!",
        "You're a superstar!",
        "Spectacular success!",
        "A true ace!",
        "Master of your craft!",
        "Simply incredible!"
    };

    private string[] _loseStringsEnglish = new string[] {
        "You can do better!",
        "You have the potential!",
        "Not bad, but you can improve!",
        "Just a little more and you'll shine!",
        "Almost perfect",
        "Close to perfection!",
        "You're on the right track",
    };

    private string[] _winStringsTurkish = new string[] {
    "Harika bir iş!",
    "Bravo!",
    "Harika bir iş çıkardınız!",
    "Sadece fantastik!",
    "Dahi seviyesindesiniz!",
    "Muhteşemsin!",
    "Sadece inanılmaz!",
    "Şık ve göz alıcı!",
    "Ustasın!",
    "Sadece mükemmel!",
    "Harikasın!",
    "İnanılmaz yeteneklisin!",
    "Kusursuz!",
    "Fantastik bir başarı!",
    "Süpersiniz!",
    "Muhteşem bir başarı!",
    "Gerçek bir as!",
    "Ustalığınızla mükemmelsiniz!",
    "Sadece inanılmaz!"
};

    private string[] _loseStringsTurkish = new string[] {
    "Daha iyi yapabilirsiniz!",
    "Potansiyeliniz var!",
    "Kötü değil, ama daha iyi olabilirsiniz!",
    "Biraz daha ve parlayacaksınız!",
    "Neredeyse mükemmel",
    "Mükemmelliğe yakınsınız!",
    "Doğru yoldasınız",
};


    private void OnEnable()
    {
        SendStepCountEvent();
    }

    private void Awake()
    {
        _pointsLevelName = "PointsLevel" + SceneManager.GetActiveScene().buildIndex;
    }

    private void Start()
    {
        _currentLanguage = PlayerPrefs.GetString("_currentLanguage");
        LoadLocalization();
        SelectString();
    }

    private void LoadLocalization()
    {
        if (_currentLanguage == "ru")
        {
            _currentWinStrigs = _winStringsRussian;
            _currentLoseStrigs = _loseStringsRussian;
        }
        if (_currentLanguage == "en")
        {
            _currentWinStrigs = _winStringsEnglish;
            _currentLoseStrigs = _loseStringsEnglish;
        }
        if (_currentLanguage == "tr")
        {
            _currentWinStrigs = _winStringsTurkish;
            _currentLoseStrigs = _loseStringsTurkish;
        }
    }

    private void SelectString()
    {
        if (_stepCounter.StepCount <= _needStepCount)
        {
            int index = Random.Range(0, _currentWinStrigs.Length);
            _string.text = _currentWinStrigs[index];
        }
        else
        {
            int index = Random.Range(0, _currentLoseStrigs.Length);
            _string.text = _currentLoseStrigs[index];
        }
    }

    public void SendStepCountEvent()
    {
        int stepCount = _stepCounter.StepCount;
        int value;
        _currentPointsCount = PlayerPrefs.GetInt(_pointsLevelName);

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
                PlayerPrefs.SetInt(_pointsLevelName, _currentPointsCount);
            }
        }

        DisplayStars(_currentPointsCount);
    }

    private void DisplayStars(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _stars[i].color = new Color(255, 255, 255);
        }
    }
}
