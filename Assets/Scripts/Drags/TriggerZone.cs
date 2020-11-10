using System;
using CameraMovement;
using UnityEngine;

namespace Drags
{
    public class TriggerZone : MonoBehaviour
    {
        [SerializeField] private Rigidbody cube;
        [SerializeField] private SpringJoint cylinder1;
        [SerializeField] private SpringJoint cylinder2;
        [SerializeField] private CameraMover cameraMover;
        [SerializeField] private ConnectionChecker connectionChecker;

        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Cube"))
            {
                ConnectObject();
                cameraMover.MoveCamera(cylinder1.transform.position.y);
                connectionChecker.CheckConnection();
            }
               
        }

        private void ConnectObject()
        {
            cylinder1.connectedBody = cube;
            cylinder2.connectedBody = cube;
        }

        public void DisconnectObject()
        {
            cylinder1.connectedBody = null;
            cylinder2.connectedBody = null;
        }

        private void OnMouseUpAsButton()
        {
            if (cylinder1.connectedBody != null && cylinder2.connectedBody != null)
            {
                DisconnectObject();
            }

            
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