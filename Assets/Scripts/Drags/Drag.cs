using System;
using CameraMovement;
using Lines;
using UnityEngine;

namespace Drags
{
    public class Drag : MonoBehaviour
    {
        [SerializeField] private float limitRadius;
        [SerializeField] private SlingShot slingShot;
        [SerializeField] private TrajectoryDrawer trajectoryDrawer;

        private CameraMover _cameraMover;
        
        #region UI

        public float LimitRadius
        {
            get => limitRadius;
            set => limitRadius = value;
        }

        #endregion

        #region Private Parameters

        private Vector3 _mOffset;
        private float _mZCoord;
        private Camera _camera;
        private Vector3 _mousePoint;

        private Vector3 _position;
        private Vector3 _initialPosition;
        private Vector3 _lastPosition;


        private SpringJoint _joint1;
        private SpringJoint _joint2;

        private Rigidbody _rigidbody;

        #endregion

        public bool CanDrag { get; set; } = true;
        public Vector3 DesiredPosition { get; set; }

        private void Awake()
        {
            _camera = Camera.main;
            _cameraMover = _camera.GetComponent<CameraMover>();
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

            _cameraMover.ZoomOut();
            ChangeStringStrength(0);
        }

        private void OnMouseDrag()
        {
            if (!CanDrag) return;

            _position = GetMouseAsWorldPoint() + _mOffset;
            LimitDrag();
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;

            if (IsValidToShoot())
            {
                trajectoryDrawer.ShowTrajectory(transform.position, GetDirection() * -slingShot.Force);
            }
            else
            {
                trajectoryDrawer.ResetTrajectory();
                _cameraMover.ZoomOut();
            }

            transform.position = _position;
        }


        private void OnMouseUp()
        {
            if (!CanDrag) return;
            _cameraMover.ZoomIn();
            ChangeStringStrength(100);
            trajectoryDrawer.ResetTrajectory();

            if (!IsValidToShoot()) return;
            RemoveSprings();
            slingShot.ShotBall(GetDirection());
            _rigidbody.constraints = RigidbodyConstraints.None;
            CanDrag = false;
        }

        private void LimitDrag()
        {
            if (_position.y < _initialPosition.y)
            {
                var allowedPosition = _position - _initialPosition;
                _position = _initialPosition + Vector3.ClampMagnitude(allowedPosition, limitRadius);
            }
            else
            {
                _position.y = Mathf.Clamp(_position.y, _initialPosition.y - limitRadius, _initialPosition.y);
                _position.x = Mathf.Clamp(_position.x, _initialPosition.x - limitRadius,
                    _initialPosition.x + limitRadius);
            }

            _position.z = -1;
        }


        private void RemoveSprings()
        {
            _joint1.connectedBody = null;
            _joint2.connectedBody = null;
        }

        private void ChangeStringStrength(int value)
        {
            _joint1.spring = value;
            _joint2.spring = value;
        }

        private bool IsValidToShoot() => Vector3.Distance(_position, _initialPosition) > 1;
        private Vector2 GetDirection() => _position - DesiredPosition;

        public void AttachSpring1(SpringJoint joint1, SpringJoint joint2)
        {
            _joint1 = joint1;
            _joint2 = joint2;
        }


        private Vector3 GetMouseAsWorldPoint()
        {
            _mousePoint = Input.mousePosition;
            _mousePoint.z = _mZCoord;

            return _camera.ScreenToWorldPoint(_mousePoint);
        }
    }
}