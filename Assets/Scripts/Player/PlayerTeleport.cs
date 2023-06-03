using DG.Tweening;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private bool _isTeleportation;
    private PlayerMover _playerMover;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    public void Teleportation(Vector3 targetPosition)
    {
        float duration = 0.5f;   
        float needPossitionY = 0.30f;
        targetPosition.y = -1.2f;

        if (!_isTeleportation)
        {
            transform.DOMoveY(targetPosition.y, duration).OnComplete(() =>
           {
               transform.DOMove(targetPosition, 0f).OnComplete(() =>
               {
                   transform.DOMoveY(needPossitionY, duration);
               });
           });
        }
    }

    private void OnEnable()
    {
        _playerMover.Moved += OnPlayerTeleported;
        _playerMover.Stoped += OnPlayerStoped;
    }

    private void OnDisable()
    {
        _playerMover.Moved -= OnPlayerTeleported;
        _playerMover.Stoped -= OnPlayerStoped;
    }

    private void OnPlayerTeleported()
    {
        _isTeleportation = false;
    }

    private void OnPlayerStoped()
    {
        _isTeleportation = true;
    }
}
