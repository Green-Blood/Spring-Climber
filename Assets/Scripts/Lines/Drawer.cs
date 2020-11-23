using UnityEngine;

namespace Lines
{
    public class Drawer : MonoBehaviour
    {
        [SerializeField] private LineCreator lineCreator;
        [SerializeField] private SpringJoint springJoint;


        private bool IsConnectedBodyNotNull() => springJoint.connectedBody != null;

        private void Update()
        {
            if (IsConnectedBodyNotNull())
            {
                lineCreator.DrawLine(transform.position, springJoint.connectedBody.transform.position);
            }
            else
            {
                lineCreator.ResetLine();
            }
        }
    }
}