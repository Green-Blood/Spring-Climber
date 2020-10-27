using UnityEngine;

public class JointRipper : MonoBehaviour
{
    [SerializeField] private Rigidbody cube;
    [SerializeField] private CameraMover cameraMover;
    [SerializeField] private LineDrawer lineDrawer;

    private SpringJoint _springJoint1;

    public bool IsEntered { get; set; }

    private void Awake()
    {
        if (gameObject.GetComponents<SpringJoint>() != null)
        {
            _springJoint1 = gameObject.GetComponent<SpringJoint>();
        }
    }

    private void Update()
    {
        CheckEntered();
    }


    private void CheckEntered()
    {
        if (IsEntered)
        {
            lineDrawer.ResetLine();
            if (_springJoint1 != null)
            {
                lineDrawer.DrawLine(transform.position, cube.transform.position);
                if (_springJoint1.connectedBody != cube)
                {
                    cameraMover.MoveCamera(_springJoint1.transform.position.y);
                    _springJoint1.connectedBody = cube;
                }
            }
        }
        else
        {
            lineDrawer.ResetLine();
        }
    }
}