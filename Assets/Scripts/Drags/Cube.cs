using System;
using CameraMovement;
using UnityEngine;

namespace Drags
{
    public class Cube : MonoBehaviour
    {
        [SerializeField] private float allowedSpeed;
        //[SerializeField] private CameraMover cameraMover;
        public float AllowedSpeed { get; set; }

        // private void Update()
        // {
        //     cameraMover.MoveCamera(transform.position.y);
        // }
    }
}