using UnityEngine;

namespace Lines
{
    public class LineCreator : MonoBehaviour
    {
        private LineRenderer _lineRenderer;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        public void DrawLine(Vector3 start, Vector3 end)
        {
            _lineRenderer.SetPosition(0, start);
            _lineRenderer.SetPosition(1, end);
        }

        public void ResetLine()
        {
            _lineRenderer.SetPosition(0, Vector3.zero);
            _lineRenderer.SetPosition(1, Vector3.zero);
        }
    }
}