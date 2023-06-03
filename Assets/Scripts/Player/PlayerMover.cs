using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    public event UnityAction StepCountChanged;
    public event UnityAction Moved;
    public event UnityAction Stoped;

    private float _duration = 0.5f;
    private float _minDistance = 0.3f;
    private float _maxDistance = 1.2f;

    private bool _isMoving;

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
        int ckickDistance = 100;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, ckickDistance))
        {
            if (hit.collider.gameObject.TryGetComponent<Cube>(out Cube cube))
            {
                Vector3 targetPosition = cube.Center.transform.position;
                float distance = Vector3.Distance(transform.position, targetPosition);

                if (distance < _maxDistance && distance > _minDistance)
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
