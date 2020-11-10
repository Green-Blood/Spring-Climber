using System;
using CameraMovement;
using UnityEngine;

namespace Drags
{
    public class Drag : MonoBehaviour
    {
        [SerializeField] private float limitRadius;
        [SerializeField] private CameraMover cameraMover;
        [SerializeField] private SlingShot slingShot;
        [SerializeField] private ConnectionChecker connectionChecker;

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


        private void OnMouseUp()
        {
            if (!CanDrag) return;
            connectionChecker.RemoveSprings();
            cameraMover.ZoomIn();
            //Debug.Log("Difference is" + GetDifference());
            slingShot.ShotBall(GetDirection());
        }

        private void LimitDrag()
        {
            var allowedPosition = _position - _initialPosition;
            _position = _initialPosition + Vector3.ClampMagnitude(allowedPosition, limitRadius);
        }

        private Vector3 GetDirection()
        {
            Vector3 direction = _position - _initialPosition;
            direction.Normalize();
            return direction;
        }


        private Vector3 GetMouseAsWorldPoint()
        {
            _mousePoint = Input.mousePosition;
            _mousePoint.z = _mZCoord;

            return _camera.ScreenToWorldPoint(_mousePoint);
        }
    }
}