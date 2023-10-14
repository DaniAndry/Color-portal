using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Menu _menu;

    private float _duration = 0.5f;
    private float _maxDistance = 1.2f;
    private float _delay;

    private bool _isMoving;
    public event UnityAction StepCountChanged;
    public event UnityAction Moved;
    public event UnityAction Stoped;

    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;

    private void Update()
    {
        _delay += Time.deltaTime;

        if (!_menu.isOpen)
        {
            if (Input.GetMouseButtonDown(0) && !_isMoving)
            {
                _startTouchPosition = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0) && !_isMoving)
            {
                _endTouchPosition = Input.mousePosition;
                TryToMoveForSwipe();
            }

            if (Input.anyKey && !_isMoving)
            {
                TryToMoveForKeyboard();
            }
        }
    }

    private void RotateTowards(Vector3 targetPosition)
    {
        transform.rotation = Quaternion.LookRotation(targetPosition - transform.position);
    }

    private void TryToMoveForSwipe()
    {
        Vector2 swipeDelta = _endTouchPosition - _startTouchPosition;
        float minSwipeDistance = 150f;

        if (swipeDelta.magnitude >= minSwipeDistance)
        {
            Vector3 direction = GetSwipeDirection(swipeDelta);
            Vector3 targetPosition = transform.position + direction * _maxDistance;

            RaycastHit hit;

            if (Physics.Raycast(transform.position, direction, out hit, _maxDistance))
            {
                if (hit.collider.gameObject.TryGetComponent<Cube>(out Cube cube))
                {
                    targetPosition = cube.Center.transform.position;
                    Move(targetPosition);
                    RotateTowards(targetPosition);
                }
            }
        }
    }

    private Vector3 GetSwipeDirection(Vector2 swipeDelta)
    {
        Vector3 direction = Vector3.zero;

        if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
        {
            direction = (swipeDelta.x > 0) ? Vector3.right : Vector3.left;
        }
        else
        {
            direction = (swipeDelta.y > 0) ? Vector3.forward : Vector3.back;
        }

        return direction;
    }

    private Vector3 GetKeyboardInput()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            direction = Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            direction = Vector3.back;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
        }

        return direction;
    }

    private void TryToMoveForKeyboard()
    {
        Vector3 direction = GetKeyboardInput();

        if (direction != Vector3.zero)
        {
            Vector3 targetPosition = transform.position + direction * _maxDistance;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, _maxDistance))
            {
                if (hit.collider.gameObject.TryGetComponent<Cube>(out Cube cube))
                {
                    targetPosition = cube.Center.transform.position;
                    Move(targetPosition);
                    RotateTowards(targetPosition);
                }
            }
        }
    }

    private void Move(Vector3 targetPosition)
    {
        if (_delay > 0.5f)
        {
            bool wasMoving = _isMoving;

            _isMoving = true;

            transform.DOMove(targetPosition, _duration).OnComplete(() =>
            {
                _isMoving = false;

                if (!wasMoving)
                {
                    Stoped?.Invoke();
                }
            });

            StepCountChanged?.Invoke();
            Moved?.Invoke();
        }
    }
}
