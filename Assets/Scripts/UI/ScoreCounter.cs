using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private float _timeToAnimate = 2f;
    private float _updateFrequency = 0.05f;

    private int _currentScore = 0;
    private int _targetScore = 0;

    public void SetScore(int newScore)
    {
        _targetScore = newScore;
        StartCoroutine(UpdateScoreCoroutine());
    }

    private IEnumerator UpdateScoreCoroutine()
    {
        int startScore = _currentScore;
        int scoreDifference = _targetScore - startScore;
        int steps = (int)(_timeToAnimate / _updateFrequency);

        for (int i = 1; i <= steps; i++)
        {
            int animatedScore = startScore + (int)((float)scoreDifference * i / steps);
            _scoreText.text = animatedScore.ToString();
            yield return new WaitForSeconds(_updateFrequency);
        }

        _currentScore = _targetScore;
        _scoreText.text = _currentScore.ToString();
    }
}
