using CameraMovement;
using UnityEngine;

namespace Drags
{
    public class TriggerZone : MonoBehaviour
    {
        [SerializeField] private CameraMover cameraMover;
        [SerializeField] private ConnectionChecker connectionChecker;

        private SpringJoint _springJoint1;


        private void Awake()
        {
            _springJoint1 = GetComponent<SpringJoint>();
        }


        private void OnJointBreak(float breakForce)
        {
            connectionChecker.DecreaseCounter();
            connectionChecker.RemoveFromList(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
          
            if (_springJoint1 == null) return;
            if (connectionChecker.Lock) return;
            var rigidBody = other.GetComponent<Rigidbody>();

            if (_springJoint1.connectedBody == rigidBody) return;
            _springJoint1.connectedBody = rigidBody;

            connectionChecker.AddtoList(gameObject);
            connectionChecker.IncreaseCounter();
            cameraMover.MoveCamera(_springJoint1.transform.position.y);
        }
    }
}