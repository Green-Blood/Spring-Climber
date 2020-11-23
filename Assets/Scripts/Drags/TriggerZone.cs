using CameraMovement;
using UnityEngine;

namespace Drags
{
    public class TriggerZone : MonoBehaviour
    {
        [SerializeField] private SpringJoint cylinder1;
        [SerializeField] private SpringJoint cylinder2;

        private bool _hasConnected;
        private float _allowedVelocity;
        private Drag _drag;

        private void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag("Cube")) return;
            if (_hasConnected) return;

            var rigidBody = other.GetComponent<Rigidbody>();
            _allowedVelocity = other.GetComponent<Cube>().AllowedSpeed;
            if (!HasSmallSpeed(rigidBody)) return;

            if (IsHigher(other.transform.position)) return;
            _drag = other.GetComponent<Drag>();
             

            ConnectObject(rigidBody);
            CalculateDifference();

            _drag.CanDrag = true;
            ConnectionChecker.Instance.CheckConnection();
            _hasConnected = true;
        }

        private bool IsHigher(Vector3 position) => position.y > transform.position.y;

        private bool HasSmallSpeed(Rigidbody rigidBody)
        {
            
            return -_allowedVelocity > rigidBody.velocity.y || rigidBody.velocity.y < _allowedVelocity;
        }

        private void ConnectObject(Rigidbody rigidBody)
        {
            cylinder1.connectedBody = rigidBody;
            cylinder2.connectedBody = rigidBody;
            _drag.AttachSpring1(cylinder1, cylinder2);
            ConnectionChecker.Instance.AddSpring(cylinder1, cylinder2);
        }

        private void CalculateDifference()
        {
            var difference = new Vector3(((cylinder2.transform.position.x + cylinder1.transform.position.x) / 2),
                transform.position.y, 0);
            _drag.DesiredPosition = difference;
        }


        #region OldCode

        // [SerializeField] private CameraMover cameraMover;
        // [SerializeField] private ConnectionChecker connectionChecker;

        // private SpringJoint _springJoint1;


        // private void Awake()
        // {
        //     _springJoint1 = GetComponent<SpringJoint>();
        // }
        //
        //
        // private void OnJointBreak(float breakForce)
        // {
        //     connectionChecker.DecreaseCounter();
        //     connectionChecker.RemoveFromList(gameObject);
        // }
        //
        // private void OnTriggerEnter(Collider other)
        // {
        //   
        //     if (_springJoint1 == null) return;
        //     if (connectionChecker.Lock) return;
        //     var rigidBody = other.GetComponent<Rigidbody>();
        //
        //     if (_springJoint1.connectedBody == rigidBody) return;
        //     _springJoint1.connectedBody = rigidBody;
        //
        //     connectionChecker.AddtoList(gameObject);
        //     connectionChecker.IncreaseCounter();
        //     cameraMover.MoveCamera(_springJoint1.transform.position.y);
        // }

        #endregion
    }
}