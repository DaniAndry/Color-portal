using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class Education : MonoBehaviour
{
    [SerializeField] private GameObject _horrizontalSlider;
    [SerializeField] private GameObject _verticalSlider;
    [SerializeField] private GameObject _educationPanel;
    [SerializeField] private PlayerMover _playerMover;

    private bool _educationEnabled;
    private bool _horrizontalMoved;

    private void Start()
    {
        _educationEnabled = true;
        _horrizontalMoved = false;
        _educationPanel.SetActive(true);
        _horrizontalSlider.SetActive(true);
    }

    private void Update()
    {
        if (_educationEnabled && !_horrizontalMoved)
        {
            _playerMover.Moved += HorrizontalMove;
        }
        else if (_educationEnabled && _horrizontalMoved)
        {
            _playerMover.Moved += VerticalMove;
        }

    }

    private void HorrizontalMove()
    {
        _horrizontalMoved = true;
        _horrizontalSlider.SetActive(false);
        _verticalSlider.SetActive(true);
    }

    private void VerticalMove()
    {
        _verticalSlider.SetActive(false);
        _educationPanel.SetActive(false);
    }
}
