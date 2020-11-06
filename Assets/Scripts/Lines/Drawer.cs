using UnityEngine;

namespace Lines
{
    public class Drawer : MonoBehaviour
    {
        [SerializeField] private Rigidbody cube;
        [SerializeField] private LineCreator lineCreator;
        [SerializeField] private SpringJoint springJoint;


        private void Update()
        {
            if (springJoint != null)
            {
                if (springJoint.connectedBody == cube)
                {
                    lineCreator.DrawLine(transform.position, cube.transform.position);
                }
                else if (springJoint.connectedBody != cube)
                {
                    lineCreator.ResetLine();
                }
            }
            else
            {
                lineCreator.ResetLine();
            }
        }
    }
}