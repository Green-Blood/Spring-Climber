using System;
using CameraMovement;
using UnityEngine;

namespace Drags
{
    public class Drag : MonoBehaviour
    {
        [SerializeField] private float limitRadius;
        [SerializeField] private CameraMover cameraMover;

        private Vector3 _mOffset;
        private float _mZCoord;
        private Camera _camera;
        private Vector3 _mousePoint;

        private Vector3 _position;
        private Vector3 _initialPosition;
        private Vector3 _lastPosition;
        private Rigidbody _rigidbody;

        public bool CanDrag { get; set; } = true;

        private void Awake()
        {
            _camera = Camera.main;
            _initialPosition = transform.position;
            _rigidbody = GetComponent<Rigidbody>();
        }


        private void OnMouseDown()
        {
            if (!CanDrag) return;
            _position = transform.position;
            _initialPosition = _position;
            _mZCoord = _camera.WorldToScreenPoint(_position).z;
            _mOffset = _position - GetMouseAsWorldPoint();
            cameraMover.ZoomOut();
             
        }

        private void OnMouseDrag()
        {
            if (!CanDrag) return;
            _position = GetMouseAsWorldPoint() + _mOffset;
            LimitDrag();
            transform.position = _position;
            
        }

        

        private void OnMouseUpAsButton()
        {
            if (!CanDrag) return;
            cameraMover.ZoomIn();
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
}