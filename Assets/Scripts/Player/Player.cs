using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
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
            TryToMove();
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
                    transform.rotation = Quaternion.LookRotation(targetPosition - transform.position);
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

        _isTeleportation = false;
    }
}
