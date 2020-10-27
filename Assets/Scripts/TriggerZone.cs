using System;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private JointRipper _jointRipper;
    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Cylinder")) return;
        _jointRipper = other.gameObject.GetComponent<JointRipper>();
        _jointRipper.IsEntered = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Cylinder")) return;
        _jointRipper.IsEntered = true;
    }


    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Cylinder")) return;
        _jointRipper.IsEntered = false;
        _boxCollider.enabled = false;
    }
}