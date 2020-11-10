using System;
using UI;
using UnityEngine;

namespace Drags
{
    public class DragLimiter : MonoBehaviour
    {
        #region OldCode

        // [SerializeField] private Drag drag;
        // [SerializeField] private ConnectionChecker connectionChecker;
        // [SerializeField] private float timeOffset;
        // [SerializeField] private EndGame endGame;
        //
        // private float _timeLimit;
        //
        // private void Awake()
        // {
        //     UpdateTimeLimit();
        // }
        //
        //
        // private void Update()
        // {
        //     if (!IsLimitedDrag())
        //     {
        //         if (Time.time > _timeLimit)
        //         {
        //             if (!IsLimitedDrag())
        //             {
        //                 endGame.ToggleEndPanel(true);
        //                 UpdateTimeLimit();
        //             }
        //         }
        //     }
        //
        //     if (!LimitFlying())
        //     {
        //         if (Time.time > _timeLimit)
        //         {
        //             if (!LimitFlying())
        //             {
        //                 endGame.ToggleEndPanel(true);
        //                 UpdateTimeLimit();
        //             }
        //         }
        //     }
        // }
        //
        // public void UpdateTimeLimit() => _timeLimit = Time.time + timeOffset;
        //
        // private bool IsLimitedDrag()
        // {
        //     drag.CanDrag = connectionChecker.IsAvailableToConnect();
        //     return drag.CanDrag;
        // }
        //
        // private bool LimitFlying()
        // {
        //     drag.CanDrag = !connectionChecker.IsFlying();
        //     return drag.CanDrag;
        // }

        #endregion
    }
}