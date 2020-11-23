using System;
using System.Collections;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace CameraMovement
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private float moveTime;
        [SerializeField] private float offset;
        [SerializeField] private float zoomOffset = 4;
        [SerializeField] private float zoomOffsetTime = 0.5f;

        [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

        private bool _zoomed;

        private float _cameraDistance;
        private float _initialCameraDistance;

        #region UI

        public float ZoomOffset
        {
            get => zoomOffset;
            set => zoomOffset = value;
        }

        public float Offset
        {
            get => offset;
            set => offset = value;
        }

        #endregion

        private void Awake()
        {
            //_cameraDistance = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance;
            _cameraDistance = cinemachineVirtualCamera.m_Lens.FieldOfView;
            _initialCameraDistance = _cameraDistance;
        }

        // public void MoveCamera(float yPosition) => transform.DOMoveY(yPosition + offset, moveTime);

        public void ZoomOut()
        {
            if (_zoomed) return;
            _zoomed = true;


            StartCoroutine(ZoomOutCoroutine());
            //cinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = zoomOffset;

            // cinemachineVirtualCamera.m_Lens.FieldOfView = zoomOffset;

            // transform.DOMoveZ(  -35f - zoomOffset, zoomOffsetTime);
            // transform.DOMoveY(  transform.position.y + offset * 2, zoomOffsetTime);
        }

        public void ZoomIn()
        {
            if (!_zoomed) return;
            _zoomed = false;


            StartCoroutine(ZoomInCoroutine());
            //cinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = _initialCameraDistance;

            // transform.DOMoveZ( -35f, zoomOffsetTime);
            // cinemachineVirtualCamera.m_Lens.FieldOfView = 40;
            //StartCoroutine(ZoomInCoroutine());
        }

        private IEnumerator ZoomOutCoroutine()
        {
            while (_cameraDistance < zoomOffset)
            {
                _cameraDistance += 0.5f;
                cinemachineVirtualCamera.m_Lens.FieldOfView = _cameraDistance;
                yield return new WaitForSeconds(0.0001f);
            }
        }

        private IEnumerator ZoomInCoroutine()
        {
            while (_cameraDistance > _initialCameraDistance)
            {
                _cameraDistance -= 0.5f;
                cinemachineVirtualCamera.m_Lens.FieldOfView = _cameraDistance;
                yield return new WaitForSeconds(0.0001f);
            }
        }
    }
}