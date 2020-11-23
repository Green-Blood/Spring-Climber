using System;
using System.Collections.Generic;
using UnityEngine;

namespace Drags
{
    public class ConnectionChecker : SingletonClass<ConnectionChecker>
    {
        private List<SpringJoint> _springJoint;

        public override void Awake()
        {
            _springJoint = new List<SpringJoint>();
        }

        public void CheckConnection()
        {
            int counter = 0;
            for (var index = _springJoint.Count - 1; index >= 0; index--)
            {
                if (_springJoint[index].connectedBody == null) continue;
                counter++;
                if (counter <= 2) continue;

                _springJoint[index].connectedBody = null;
                RemoveSpring(_springJoint[index]);
            }
        }

        public void AddSpring(SpringJoint joint1, SpringJoint joint2)
        {
            _springJoint.Add(joint1);
            _springJoint.Add(joint2);
        }

        private void RemoveSpring(SpringJoint joint1) => _springJoint.Remove(joint1);


        #region OldCode

        private void Start()
        {
            // _springJoint = new SpringJoint[LevelGenerator.Instance.Cylinders.Count];
            //
            // for (int i = 0; i < LevelGenerator.Instance.Cylinders.Count; i++)
            // {
            //     _springJoint[i] =  LevelGenerator.Instance.Cylinders[i].GetComponent<SpringJoint>();
            // }
        }

        // public void RemoveSprings()
        // {
        //     foreach (var joint in _springJoint)
        //     {
        //         if (joint != null)
        //         {
        //             joint.connectedBody = null;
        //             drag.CanDrag = false;
        //         }
        //     }
        // }
        //
        // //[SerializeField] private GameObject[] cylinders;
        // [SerializeField] private GameObject cube;
        // [SerializeField] private DragLimiter dragLimiter;
        //
        // private int _jointsCounter;
        // private List<GameObject> _attached;
        // private float _theFarest;
        // private GameObject _theFarestCylinder;
        //
        // private bool _lock = false;
        //
        // public bool Lock
        // {
        //     get => _lock;
        // }
        //
        //
        // private void Awake()
        // {
        //     _attached = new List<GameObject>();
        // }
        //
        // private void Update()
        // {
        //     _lock = _jointsCounter == 2;
        // }
        //
        // public void IncreaseCounter()
        // {
        //     _jointsCounter++;
        //     if (_jointsCounter > 2)
        //     {
        //         CheckFarest();
        //         _lock = false;
        //     }
        //
        //
        //     if (_jointsCounter == 1)
        //     {
        //         dragLimiter.UpdateTimeLimit();
        //         _lock = false;
        //     }
        //
        //     Debug.Log("Increased Counter is " + _jointsCounter);
        // }
        //
        // public void DecreaseCounter()
        // {
        //     _jointsCounter--;
        //     if (_jointsCounter > 2)
        //     {
        //         CheckFarest();
        //     }
        //
        //     if (_jointsCounter == 1)
        //     {
        //         dragLimiter.UpdateTimeLimit();
        //     }
        //
        //     Debug.Log("Decreased counter is " + _jointsCounter);
        // }
        //
        // private void CheckFarest()
        // {
        //     if (_attached.Count == 0) return;
        //     for (int i = 0; i < _attached.Count; i++)
        //     {
        //         if (_attached[i].GetComponent<SpringJoint>() == null) continue;
        //         if (!(_theFarest < Vector3.Distance(cube.transform.position, _attached[i].transform.position)))
        //             continue;
        //
        //         _theFarest = Vector3.Distance(cube.transform.position, _attached[i].transform.position);
        //         _theFarestCylinder = _attached[i];
        //     }
        //
        //     if (_theFarestCylinder.GetComponent<SpringJoint>().connectedBody != cube.GetComponent<Rigidbody>()) return;
        //     _theFarestCylinder.GetComponent<SpringJoint>().connectedBody = null;
        //
        //     DecreaseCounter();
        //     _attached.Remove(_theFarestCylinder);
        //     _theFarest = 0;
        //     _theFarestCylinder = null;
        // }
        //
        // public void AddtoList(GameObject cylinder)
        // {
        //     _attached.Add(cylinder);
        // }
        //
        // public void RemoveFromList(GameObject cylinder)
        // {
        //     if (_attached.Contains(cylinder))
        //     {
        //         _attached.Remove(cylinder);
        //     }
        // }
        //
        // public bool IsAvailableToConnect() => _jointsCounter != 1;
        // public bool IsFlying() => _jointsCounter == 0;
        //

        #endregion
    }
}