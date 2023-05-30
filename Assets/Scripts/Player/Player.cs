using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private float _duration = 0.5f;
    private float _maxDistance = 1.2f;
    private Animator _playerAnimator;

    private bool _isTeleportation;
    private bool _isMoving;

    private static int Idle = Animator.StringToHash("Idle");
    private static int Run = Animator.StringToHash("Run");

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !_isMoving)
        {
            TryToMove();

            if (_isMoving)
            {
                _playerAnimator.Play(Run);
            }
            else
            {
                _playerAnimator.Play(Idle);
            }
        }
    }

    public void Teleportation(Vector3 targetPosssition)
    {
        targetPosssition.y = -1.2f;

        if (!_isTeleportation)
        {
            _isTeleportation = true;

            transform.DOMoveY(-1.2f, 0.5f).OnComplete(() =>
            {
                transform.DOMove(targetPosssition, 0f).OnComplete(() =>
                {
                    transform.DOMoveY(0.30f, 0.5f);
                });
            });
        }
    }

    private void TryToMove()
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
                    _isMoving = false;
                }
            }
        }
    }

    private void Move(Vector3 targetPosition)
    {
        _isMoving = true;
        Vector3 rotate = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        _playerAnimator.Play(Run);
        transform.DOMove(targetPosition, _duration);
        transform.DOLookAt(rotate, 0.1f);

        _isTeleportation = false;
    }
}





