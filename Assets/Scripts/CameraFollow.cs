using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothDuration = 0.5f;

  [SerializeField]  private Vector3 _offset;

    private void LateUpdate()
    {
    //    _offset = new Vector3(_offset.x, 7, -7);

        if (_target != null)
        {
            Vector3 desiredPosition = _target.position + _offset;
            transform.DOMove(desiredPosition, _smoothDuration);
        }
    }
}
