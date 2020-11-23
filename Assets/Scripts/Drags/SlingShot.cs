using System;
using UnityEngine;

namespace Drags
{
    public class SlingShot : MonoBehaviour
    {
        [SerializeField] private float force;
        private Rigidbody _rigidbody;
        #region UI

        public float Force
        {
            get => force;
            set => force = value;
        }

        #endregion
        
        private void Awake() => _rigidbody = GetComponent<Rigidbody>();
        public void ShotBall(Vector2 direction) => _rigidbody.AddForce(direction * -force, ForceMode.Impulse);
    }
}