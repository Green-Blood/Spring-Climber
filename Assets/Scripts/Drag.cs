using System;
using UnityEngine;

public class Drag : MonoBehaviour
{
    [SerializeField] private float limitRadius;

    private Vector3 _mOffset;
    private float _mZCoord;
    private Camera _camera;
    private Vector3 _mousePoint;

    private Vector3 _position;
    private Vector3 _initialPosition;
    private Vector3 _lastPosition;

    private void Awake()
    {
        _camera = Camera.main;
        _initialPosition = transform.position;
    }


    private void OnMouseDown()
    {
        _position = transform.position;
        _initialPosition = _position;
        _mZCoord = _camera.WorldToScreenPoint(_position).z;
        _mOffset = _position - GetMouseAsWorldPoint();
    }

    private void OnMouseDrag()
    {
        _position = GetMouseAsWorldPoint() + _mOffset;
        LimitDrag();
        transform.position = _position;
    }

    private void LimitDrag()
    {
        var allowedPosition = _position - _initialPosition;
        _position = _initialPosition + Vector3.ClampMagnitude(allowedPosition, limitRadius);
    }


    private Vector3 GetMouseAsWorldPoint()
    {
        _mousePoint = Input.mousePosition;
        _mousePoint.z = _mZCoord;

        return _camera.ScreenToWorldPoint(_mousePoint);
    }
}