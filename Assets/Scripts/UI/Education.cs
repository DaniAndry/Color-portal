using UnityEngine;
using Agava.WebUtility;


public class Education : MonoBehaviour
{
    [SerializeField] private GameObject _horrizontalSlider;
    [SerializeField] private GameObject _verticalSlider;
    [SerializeField] private GameObject _educationPanel;
    [SerializeField] private GameObject _horrizontalButtons;
    [SerializeField] private GameObject _verticalButtons;
    [SerializeField] private PlayerMover _playerMover;

    private bool _isEducationEnabled;
    private bool _isHorrizontalMoved;
    private bool _isMobileGame;


    private void Start()
    {
        _isEducationEnabled = true;
        _isHorrizontalMoved = false;
        _educationPanel.SetActive(true);

        if (Device.IsMobile)
        {
            _isMobileGame = true;
            _horrizontalSlider.SetActive(true);
        }
        else
        {
            _isMobileGame = false;
            _horrizontalButtons.SetActive(true);
        }
    }

    private void Update()
    {
        if (_isEducationEnabled && !_isHorrizontalMoved)
        {
            _playerMover.Moved += HorrizontalMove;
        }
        else if (_isEducationEnabled && _isHorrizontalMoved)
        {
            _playerMover.Moved += VerticalMove;
        }
    }

    private void HorrizontalMove()
    {
        _isHorrizontalMoved = true;

        if (_isMobileGame)
        {
            _horrizontalSlider.SetActive(false);
            _verticalSlider.SetActive(true);
        }
        else
        {
            _horrizontalButtons.SetActive(false);
            _verticalButtons.SetActive(true);
        }
    }

    private void VerticalMove()
    {
        _verticalButtons.SetActive(false);
        _verticalSlider.SetActive(false);
        _educationPanel.SetActive(false);
    }
}
