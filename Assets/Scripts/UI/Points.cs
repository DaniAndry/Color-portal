using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCount;
    private int _count;
    private int _levels = 13;
    public int Count => _count;

    private void Awake()
    {
        Calculate();
    }

    public int Calculate()
    {
        _count = 0;

        for (int i = 0; i < _levels; i++)
        {
            _count += PlayerPrefs.GetInt("PointsLevel" + i, 0);
        }

        _textCount.text = _count.ToString();
        return _count;
    }

    public void ClearState()
    {
        for (int i = 0; i < _levels; i++)
        {
            PlayerPrefs.SetInt("PointsLevel" + i, 0);
        }
    }
}
