using System;
using System.Collections.Generic;
using UnityEngine;

namespace Drags
{
    public class ConnectionChecker : MonoBehaviour
    {
        //[SerializeField] private GameObject[] cylinders;
        [SerializeField] private GameObject cube;
        [SerializeField] private DragLimiter dragLimiter;

        private int _jointsCounter;
        private List<GameObject> _attached;
        private float _theFarest;
        private GameObject _theFarestCylinder;

        private bool _lock = false;

        public bool Lock
        {
            get => _lock;
        }


        private void Awake()
        {
            _attached = new List<GameObject>();
        }

        private void Update()
        {
            _lock = _jointsCounter == 2;
        }

        public void IncreaseCounter()
        {
            _jointsCounter++;
            if (_jointsCounter > 2)
            {
                CheckFarest();
                _lock = false;
            }


            if (_jointsCounter == 1)
            {
                dragLimiter.UpdateTimeLimit();
                _lock = false;
            }

            Debug.Log("Increased Counter is " + _jointsCounter);
        }

        public void DecreaseCounter()
        {
            _jointsCounter--;
            if (_jointsCounter > 2)
            {
                CheckFarest();
            }

            if (_jointsCounter == 1)
            {
                dragLimiter.UpdateTimeLimit();
            }

            Debug.Log("Decreased counter is " + _jointsCounter);
        }

        private void CheckFarest()
        {
            if (_attached.Count == 0) return;
            for (int i = 0; i < _attached.Count; i++)
            {
                if (_attached[i].GetComponent<SpringJoint>() == null) continue;
                if (!(_theFarest < Vector3.Distance(cube.transform.position, _attached[i].transform.position)))
                    continue;

                _theFarest = Vector3.Distance(cube.transform.position, _attached[i].transform.position);
                _theFarestCylinder = _attached[i];
            }

            if (_theFarestCylinder.GetComponent<SpringJoint>().connectedBody != cube.GetComponent<Rigidbody>()) return;
            _theFarestCylinder.GetComponent<SpringJoint>().connectedBody = null;

            DecreaseCounter();
            _attached.Remove(_theFarestCylinder);
            _theFarest = 0;
            _theFarestCylinder = null;
        }

        public void AddtoList(GameObject cylinder)
        {
            _attached.Add(cylinder);
        }

        public void RemoveFromList(GameObject cylinder)
        {
            if (_attached.Contains(cylinder))
            {
                _attached.Remove(cylinder);
            }
        }

        public bool IsAvailableToConnect() => _jointsCounter != 1;
        public bool IsFlying() => _jointsCounter == 0;
    }
}