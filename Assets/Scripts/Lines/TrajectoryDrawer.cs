using System;
using UnityEngine;

namespace Lines
{
    public class TrajectoryDrawer : MonoBehaviour
    {
        private LineRenderer _lineRenderer;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        public void ShowTrajectory(Vector3 origin, Vector3 speed)
        {
            Vector3[] points = new Vector3[25];
            _lineRenderer.positionCount = points.Length;

            for (int i = 0; i < points.Length; i++)
            {
                float time = i * 0.1f;
                points[i] = origin + speed * time + Physics.gravity * time * time / 2f;
            }

            _lineRenderer.SetPositions(points);
        }

        public void ResetTrajectory() => _lineRenderer.positionCount = 0;
    }
}