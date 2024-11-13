using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCount;

    private PlayerData _playerData;
    private JsonSaver _jsonSaver;
    private int _count;
    private int _levels = 21;
    private int _points;

    public int Count => _count;

    private void Awake()
    {
       // ClearState();    
        _playerData = GetComponent<PlayerData>();
        _jsonSaver = GetComponent<JsonSaver>();
        Calculate();
    }

    private void ClearState()
    {
        for (int i = 0; i < _levels; i++)
        {
            PlayerPrefs.SetInt("PointsLevel" + i, 0);
        }
    }

    public int Calculate()
    {
        _count = 0;

        for (int i = 0; i < _levels; i++)
        {
            _count += PlayerPrefs.GetInt("PointsLevel" + i, 0);
            _points += PlayerPrefs.GetInt("ScoreCount" + i, 0);
        }

        PlayerPrefs.SetInt("PlayerPoints", _count);
        PlayerPrefs.SetInt("ScoreCount", _points);
        _textCount.text = _count.ToString();

        if (_count > 0 && _points > 0)
        {
            _playerData = _playerData.SetPlayerData(_count, _points);

            _jsonSaver.SaveData(_playerData);
        }

        return _count;
    }
}