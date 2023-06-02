using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction StepCountChanged;

    [SerializeField] private Animator _playerAnimator;

    private float _duration = 0.5f;
    private float _maxDistance = 1.2f;

    private bool _isTeleportation;
    private bool _isMoving;

    private static int Idle = Animator.StringToHash("Idle");
    private static int Run = Animator.StringToHash("Run");

    private void Start()
    {
        _playerAnimator.Play(Idle);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !_isMoving)
        {
            TryToMoveForMouse();
        }

        if (Input.anyKey && !_isMoving)
        {
            TryToMoveForKeyboard();
        }
    }

    public void Teleportation(Vector3 targetPosition)
    {
        targetPosition.y = -1.2f;

        if (!_isTeleportation)
        {
            _isTeleportation = true;

            transform.DOMoveY(-1.2f, 0.5f).OnComplete(() =>
            {
                transform.DOMove(targetPosition, 0f).OnComplete(() =>
                {
                    transform.DOMoveY(0.30f, 0.5f);
                });
            });
        }
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

    private void RotateTowards(Vector3 targetPosition)
    {
        transform.rotation = Quaternion.LookRotation(targetPosition - transform.position);
    }

    private void TryToMoveForMouse()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
        {
            if (hit.collider.gameObject.TryGetComponent<Cube>(out Cube cube))
            {
                Vector3 targetPosition = cube.Center.transform.position;
                float distance = Vector3.Distance(transform.position, targetPosition);

                if (distance < _maxDistance)
                {
                    Move(targetPosition);
                    RotateTowards(targetPosition);
                }
            }
        }
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
        _playerAnimator.Play(Run);
        _isMoving = true;

        transform.DOMove(targetPosition, _duration).OnComplete(() =>
        {
            _playerAnimator.Play(Idle);
            _isMoving = false;
        });

        StepCountChanged?.Invoke();

        _isTeleportation = false;
    }
}
