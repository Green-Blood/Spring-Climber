using DG.Tweening;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float moveTime;
    public void MoveCamera(float yPosition) => transform.DOMoveY(yPosition, moveTime);
}