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

        private bool _zoomed;
        public void MoveCamera(float yPosition) => transform.DOMoveY(yPosition + offset, moveTime);

        public void ZoomOut()
        {
            if (_zoomed) return;
            _zoomed = true;
            transform.DOMoveZ(  -45f, zoomOffsetTime);
        }

        public void ZoomIn()
        {
            if (!_zoomed) return;
            _zoomed = false;
            transform.DOMoveZ( -35f, zoomOffsetTime);

        }
    }
}