using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] private Focus _focus;
    [SerializeField] private Transform _secondHand;
    [SerializeField] private FinalCube _finalCube;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _closeButton;

    private Animation _animation;

    private bool _isRun = true;

    private float _seconds;

    private void Start()
    {
        _finalCube.Finished += DeactiveWach;
        _focus.FocusMissing += StopTimmer;
        _focus.FocusIsBack += StartTimmer;

        _menuButton.onClick.AddListener(StopTimmer);
        _closeButton.onClick.AddListener(StartTimmer);
        _animation = GetComponent<Animation>();
        _animation.Play();
    }

    private void OnDisable()
    {
        _finalCube.Finished -= DeactiveWach;
        _focus.FocusMissing -= StopTimmer;
        _focus.FocusIsBack -= StartTimmer;
    }

    private void FixedUpdate()
    {
        if (_isRun)
        {
            UpdateTime();
        }
    }

    private void DeactiveWach()
    {
        gameObject.SetActive(false);
    }

    public int GetTime()
    {
        return (int)_seconds;
    }

    private void UpdateTime()
    {
        if (_isRun)
        {
            RotateClockHand();

            _seconds += Time.deltaTime;
        }
    }

    private void StopTimmer()
    {
        _isRun = false;
        _animation.Stop();
    }

    private void StartTimmer()
    {
        _isRun = true;
        _animation.Play();
    }

    private void RotateClockHand()
    {
        float secondRotation = 360f * _seconds / 60f;

        _secondHand.localRotation = Quaternion.Euler(0f, 0f, -secondRotation);
    }
}
