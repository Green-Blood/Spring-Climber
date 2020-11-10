using System;
using UnityEngine;

namespace Drags
{
    public class SlingShot : MonoBehaviour
    {
        [SerializeField] private float force;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void ShotBall(Vector3 direction)
        {
            _rigidbody.AddForce(direction * -force, ForceMode.Impulse);
        }
    }
}
