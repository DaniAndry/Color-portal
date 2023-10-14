using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneButton : MonoBehaviour
{
    [SerializeField] private NeedPoints _needPoints;
    [SerializeField] private Points _points;
    [SerializeField] private GameObject _notEnoughPoint;
    [SerializeField] private GameObject _clock;

    private int _currentSceneIndex;

    private void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        _points.Calculate();
        _clock.SetActive(false);
    }

    public void LoadNextScene()
    {
        _notEnoughPoint.SetActive(false);

        int nextSceneIndex = _currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings&& IsPointsEnough())
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            _notEnoughPoint.SetActive(true);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(_currentSceneIndex);
    }

    private bool IsPointsEnough()
    {
        if (_needPoints.TryToEnter(_currentSceneIndex-2, _points.Calculate()))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

