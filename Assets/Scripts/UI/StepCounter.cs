using UnityEngine;
using TMPro;

public class StepCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _count;
    [SerializeField] private PlayerMover _player;
    private Animation _animation;
    private int _stepCount;

    public int StepCount => _stepCount;

    private void Start()
    {
        _animation = GetComponent<Animation>();
    }

    private void OnEnable()
    {
        _player.StepCountChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.StepCountChanged -= OnValueChanged;
    }

    private void OnValueChanged()
    {
        _stepCount++;
        _animation.Play();
        _count.text = _stepCount.ToString();
    }
}
